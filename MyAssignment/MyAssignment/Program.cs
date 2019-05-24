using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyAssignment
{
    class Program
    {

        static TourListing ListTour = new TourListing();

        static void Main(string[] args)
        {

            Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
                                                        //your sample code
            System.Threading.Thread.Sleep(0);
            stopwatch.Stop();
            //Console.WriteLine("Elapsed time: {0} milliseconds", stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch1 = new Stopwatch();

            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            Console.WriteLine("Reading input from {0}", args[1]);

            Console.WriteLine("Reading input from {0}", args[2]);


            List<Tour> T = ListTour.GetTourList(args[1]);

            List<double> distanceresult = new List<double>();

            for (int i = 0; i < T.Count - 1; i++) //calculate Eucidilian distance & add to distanceresult list
            {
                Distance.DistanceCalcTT(T[i], T[i + 1]);

                distanceresult.Add(Distance.DistanceCalcTT(T[i], T[i + 1]));
            }

            double tour_length = distanceresult.Sum(); // sum of all distance = tour_length

            double tour_time = (tour_length / plane.speed) + ((plane.landingtime / 60) + (plane.landingtime / 60)) * T.Count; //tour time

            double currentrange = plane.range; // make a double since the range will change

            List<double> stationdurations = new List<double>(); // durations between each station

            for (int i = 0; i < distanceresult.Count; i++) //adds the durations into an array
            {
                stationdurations.Add((distanceresult[i] / plane.speed) * 60);
            }

            //string htime = args[3].Substring(0, 2);

            //string mtime = args[3].Substring(3);

            //int hourtime = Convert.ToInt32(htime);

            //int mintime = Convert.ToInt32(mtime);

            //List<string> departtime = new List<string>();
            //List<string> arrivaltime = new List<string>();

            //for (int i = 0; i < distanceresult.Count; i++) //adds the values on to depart time and arrival time list
            //{

            //    string timedepart = string.Format("{0:00}:{1:00}", hourtime, mintime);
            //    departtime.Add(timedepart);

            //    mintime = mintime + Convert.ToInt32(stationdurations[i]);

            //    if (mintime > 59)
            //    {
            //        hourtime = hourtime + 1;
            //        mintime = mintime - 60;
            //    }

            //    if (hourtime > 23)
            //    {
            //        hourtime = 00;
            //    }

            //    string timearrival = string.Format("{0:00}:{1:00}", hourtime, mintime);
            //    arrivaltime.Add(timearrival);

            //}

            Console.WriteLine("Tour Length: {0} kilometres", tour_length);

            Console.WriteLine("Tour Time: {0} hrs", tour_time);

            for (int i = 0; i < T.Count - 1; i++) //prints the tour details
            {

                Console.WriteLine("{0}\t->\t{1}\t{2}", T[i].Name, T[i + 1].Name, distanceresult[i]);

                //currentrange = currentrange - ((distanceresult[i] / plane.speed) * 60); // range - the length of each station

                //if (currentrange < ((distanceresult[i] / plane.speed) * 60)) //if current range is lower than the next station length, refuel
                //{
                //    currentrange = plane.range; //refuel

                //    tour_time = tour_time + (plane.refueltime / 60);

                //    Console.WriteLine("***refuel {0} minutes ***", plane.refueltime);
                //}

            }

            Console.ReadLine();
        }
    }
}
