using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;

namespace Assignment
{
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
                                                        //your sample code
            System.Threading.Thread.Sleep(0);
            stopwatch.Stop();
            //Console.WriteLine("Elapsed time: {0} milliseconds", stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch1 = new Stopwatch();

            // Begin timing.
            //stopwatch1.Start();

            // Do something.
            //for (int i = 0; i < 1000; i++)
            //{
            //    System.Threading.Thread.Sleep(1);
            //}

            // Stop timing.
            //stopwatch1.Stop();


            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            Console.WriteLine("Reading input from {0}", args[1]);
            Station.readstation(args[1]);

            Console.WriteLine("Reading input from {0}", args[2]);
            plane.readplanespecs(args[2]);

            tour.printtour();

            if (args.Contains("-o") == true)
            {
                string outputFile = args[5]; //write file
                FileStream outFile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                Console.WriteLine("Saving itinerary to {0}", args[5]);
                writer.Write(tour.itinerary);

                writer.Close();
                outFile.Close();
            }

            stations.Sta(Station.station_name[0], Convert.ToInt32(Station.station_x[0]), Convert.ToInt32(Station.station_y[0]));

            //List<string> station_name = new List<string>();
            //List<string> station_x = new List<string>();
            //List<string> station_y = new List<string>();
            //List<double> distanceresult = new List<double>();
            //string[] stationDetails;

            //string fileLocation = "";

            ////Easy way to read
            //string[] filelines = File.ReadAllLines(fileLocation);

            ////Other approach: file stream
            //FileStream inFile = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
            //StreamReader reader = new StreamReader(inFile);

            //string line;

            //while ((line = reader.ReadLine()) != null)
            //{
            //    stationDetails = line.Split(' ');

            //    station_name.Add(stationDetails[0]);

            //    station_x.Add(stationDetails[1]);

            //    station_y.Add(stationDetails[2]);

            //}

            //if -o exists in the argument array
            //    print itinery.txt

            //String output = Console.ReadLine();

            //if (args.Contains("-o") == true)
            //{
            //    // writing to file
            //    string outputFile = "itinerary.txt";
            //    FileStream outFile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
            //    StreamWriter writer = new StreamWriter(outFile);
            //    writer.WriteLine(output);
            //    //closes everything
            //    writer.Close();
            //    outFile.Close();
            //}

            //string htime = args[3].Substring(0, 2);

            //string mtime = args[3].Substring(3);

            //int hourtime = Convert.ToInt32(htime);

            //int mintime = Convert.ToInt32(mtime);

            //Console.WriteLine("{0}:{1}", hourtime, mintime);

            //TimeSpan depart = new TimeSpan(hourtime, mintime, 00);
            //TimeSpan arrive = new TimeSpan(00, 38, 00);
            //TimeSpan newTime = depart + arrive;
            //Console.WriteLine("{0} - {1} = {2}", depart, arrive, newTime);

            //List<double> distanceresult = new List<double>();
            //double distancesum = distanceresult.Sum();
            //double timetour = distancesum / plane.speed;




            //Console.WriteLine("Tour length: {0}", distancesum);
            //Console.WriteLine("Tour time: {0} hours", timetour);


            //for (int i = 0; i < 5; i++)
            //{
            //    double result1 = Math.Pow((Convert.ToInt32(station.station_x[i]) - Convert.ToInt32(station.station_x[i + 1])), 2);
            //    double result2 = Math.Pow((Convert.ToInt32(station.station_y[i]) - Convert.ToInt32(station.station_y[i + 1])), 2);

            //    double fresult = Math.Sqrt(result1 + result2);

            //    distanceresult.Add(fresult);

            //    Console.WriteLine("{0}\t->\t{1}\t{2}", station.station_name[i], station.station_name[i + 1], distanceresult[i]);
            //}
            //double homeresult1 = Math.Pow((Convert.ToInt32(station.station_x[station.station_x.Count - 1]) - Convert.ToInt32(station.station_x[0])), 2);
            //double homeresult2 = Math.Pow((Convert.ToInt32(station.station_y[station.station_y.Count - 1]) - Convert.ToInt32(station.station_y[0])), 2);
            //double homeresults = Math.Sqrt(homeresult1 + homeresult2);

            //Console.WriteLine("{0}\t->\t{1}\t{2}", station.station_name[station.station_x.Count - 1], station.station_name[0], homeresults);

            Console.ReadLine();

            //reader.Close();
            //inFile.Close();

        }
    }
}
