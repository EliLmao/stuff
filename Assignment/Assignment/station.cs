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

            reader.Close();
            inFile.Close();
        }

    }
}
