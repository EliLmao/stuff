using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Station
    {

        //public int x;
        //public int y;
        //public string stationname;

        public static List<string> station_name = new List<string>();
        public static List<string> station_x = new List<string>();
        public static List<string> station_y = new List<string>();
        public static string[] stationDetails;

        public static void readstation(string fileLocation)
        {

            //Easy way to read
            string[] filelines = File.ReadAllLines(fileLocation);

            //Other approach: file stream
            FileStream inFile = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                stationDetails = line.Split(' ');

                station_name.Add(stationDetails[0]);

                station_x.Add(stationDetails[1]);

                station_y.Add(stationDetails[2]);

            }

            //List<string> ListOfStations = new List<string>();

            //for (int i = 0; i < Station.station_name.Count; i++)
            //{
            //    ListOfStations.Add(new Station(Station.station_name[i], Station.station_x[i], Station.station_y[i]));
            //}

            //foreach (line in mail.txt)
            //{
            //    Station station = new Station();

            //    for (int i = 0; i < Station.station_name.Count; i++)
            //    {
            //        ListOfStations.Add(station(Station.station_name[i], Station.station_x[i], Station.station_y[i]));
            //    }
            //}



            //if you have a list of Stations
            //Station class items
            //make one for each item in the mail file
            //with a forloop
            //so parse it out in the same way you have for your lists
            //but do this in a for each line in inputfile
            //ListOfStations.Add(new Station(StationName, X, Y))

            reader.Close();
            inFile.Close();
        }

    }
}
