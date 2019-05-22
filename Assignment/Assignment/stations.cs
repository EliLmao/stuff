using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class stations
    {
        private int x_cord;
        private int y_cord;
        private string name { get; }

        //String[] argumentss = Environment.GetCommandLineArgs();

        //public void readstation(string stationName, int x_coord, int y_coord)
        //{
        //    this.StationName = stationName;
        //    this.X_coord = x_coord;
        //    this.Y_coord = y_coord;
        //}
        //public string StationName { set; get; }
        //public int X_coord { set; get; }
        //public int Y_coord { set; get; }

        public static List<string> station_name = new List<string>();
        public static List<string> station_x = new List<string>();
        public static List<string> station_y = new List<string>();
        List<double> distanceresult = new List<double>();
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

        public stations(string recievedName, int y, int x)
        {
            name = recievedName;
            x_cord = x;
            y_cord = y;
        }

        public void calcdistance()
        {
            for (int i = 0; i < distanceresult.Count; i++)
            {
                int x0 = Convert.ToInt32(stations.station_x[i]);
                int y0 = Convert.ToInt32(stations.station_y[i]);

                int x1 = Convert.ToInt32(stations.station_x[i + 1]);
                int y1 = Convert.ToInt32(stations.station_y[i + 1]);

                int dX = x1 - x0;
                int dY = y1 - y0;
                double distance = Math.Sqrt(dX * dX + dY * dY);
            }

        }

    }
}


(wsx, edc, rfv)
(20, 300, 300)
(200, 300, 100)