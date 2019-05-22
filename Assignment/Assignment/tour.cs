using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment
{
    public static class tour
    {
        public static string itinerary = "";
        public static void printtour()
        {
            

            List<double> distanceresult = new List<double>();

            String[] arguments = Environment.GetCommandLineArgs(); //gets the command line arguments

            //adds post office for the end of the tour
            station.station_name.Add(station.station_name[0]);
            station.station_x.Add(station.station_x[0]);
            station.station_y.Add(station.station_y[0]);

            for (int i = 0; i < station.station_name.Count - 1; i++) //calculate Eucidilian distance & add to distanceresult list
            {
                //double fresult = Math.Sqrt(Math.Pow(Convert.ToInt32(station.station_x[i]) - Convert.ToInt32(station.station_x[i + 1]), 2) 
                //    + Math.Pow(Convert.ToInt32(station.station_y[i]) - Convert.ToInt32(station.station_y[i + 1]), 2));

                int x0 = Convert.ToInt32(station.station_x[i]);
                int y0 = Convert.ToInt32(station.station_y[i]);

                int x1 = Convert.ToInt32(station.station_x[i + 1]);
                int y1 = Convert.ToInt32(station.station_y[i + 1]);

                int dX = x1 - x0;
                int dY = y1 - y0;
                double distance = Math.Sqrt(dX * dX + dY * dY);

                distanceresult.Add(distance);
            }


            double tour_length = distanceresult.Sum(); // sum of all distance = tour_length
            
            double tour_time = (tour_length / plane.speed) + ((plane.landingtime/60) + (plane.landingtime/60)) * station.station_name.Count; //tour time

            double currentrange = plane.range; // make a double since the range will change

            List<double> stationdurations = new List<double>(); // durations between each station

            for (int i = 0; i < distanceresult.Count; i++) //adds the durations into an array
            {
                stationdurations.Add((distanceresult[i] / plane.speed) * 60);
            }

            //formats the time from the argument commandline into a 24:00 hour clock format

            string htime = arguments[4].Substring(0, 2);

            string mtime = arguments[4].Substring(3);

            int hourtime = Convert.ToInt32(htime);

            int mintime = Convert.ToInt32(mtime);

            List<string> departtime = new List<string>();
            List<string> arrivaltime = new List<string>();

            for (int i = 0; i < distanceresult.Count; i++) //adds the values on to depart time and arrival time list
            {


                string timedepart = string.Format("{0:00}:{1:00}", hourtime, mintime);
                departtime.Add(timedepart);

                mintime = mintime + Convert.ToInt32(stationdurations[i]);

                if (mintime > 59)
                {
                    hourtime = hourtime + 1;
                    mintime = mintime - 60;
                }

                if (hourtime > 23)
                {
                    hourtime = 00;
                }

                string timearrival = string.Format("{0:00}:{1:00}", hourtime, mintime);
                arrivaltime.Add(timearrival);

            }

            

            //itinerary += String.Format("Tour Length: {0} kilometres\n", Math.Round(tour_length, 2));

            Console.WriteLine("Tour Length: {0} kilometres", Math.Round(tour_length, 2));

            itinerary += String.Format("Tour Length: {0} kilometres", Math.Round(tour_length, 2));
            
            for (int i = 0; i < station.station_name.Count - 1; i++) //prints the station details (name, x, y etc.)
            {

                itinerary += String.Format("{0}\t->\t{1}\t{2}\t{3}\t{4} metres\t{5} mins", station.station_name[i], station.station_name[i + 1], 
                    departtime[i], arrivaltime[i], Math.Round(distanceresult[i], 2), Math.Round(stationdurations[i], 2));

                Console.WriteLine("{0}\t->\t{1}\t{2}\t{3}\t{4} metres\t{5} mins", station.station_name[i], station.station_name[i + 1], 
                    departtime[i], arrivaltime[i] , Math.Round(distanceresult[i], 2), Math.Round(stationdurations[i], 2));
                
                currentrange = currentrange - ((distanceresult[i] / plane.speed) * 60); // range - the length of each station

                if (currentrange < ((distanceresult[i] / plane.speed) * 60)) //if current range is lower than the next station length, refuel
                {
                    currentrange = plane.range;

                    tour_time = tour_time + (plane.refueltime/60);
                    
                    Console.WriteLine("***refuel {0} minutes ***", plane.refueltime);
                    itinerary += String.Format("***refuel {0} minutes ***", plane.refueltime);
                }

                //for (int z = 0; z < 20; z++)
                //{
                    // writing to file
                    
                    
                    //writer.WriteLine(hi);
                    //closes everything

                //}


            }


            Console.WriteLine("Tour Time: {0} hours",Math.Round(tour_time, 2));

            //TimeSpan t = TimeSpan.FromHours(6.23);

            //string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
            //    t.Hours,
            //    t.Minutes,
            //    t.Seconds,
            //    t.Milliseconds);

            //Console.WriteLine(answer);

            //String.Format("{0} days, {1} hours, {2} minutes, {3} seconds",
            //    span.Days, span.Hours, span.Minutes, span.Seconds);

            itinerary += String.Format("Tour Time: {0} hours", Math.Round(tour_time, 2));


            

            

            //Console.WriteLine("{0}\t->\t{1}\t{2}", station.station_name[station.station_x.Count - 1], station.station_name[0], homefresult);
            //double homefresult = Math.Sqrt(Math.Pow(Convert.ToInt32(station.station_x[station.station_x.Count - 1]) - Convert.ToInt32(station.station_x[0]), 2)
            //        + Math.Pow(Convert.ToInt32(station.station_y[station.station_y.Count - 1]) - Convert.ToInt32(station.station_y[0]), 2));
        }

    }
}
