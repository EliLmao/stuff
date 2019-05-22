using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class stations
    {
        private int x_cord;
        private int y_cord;
        private string name;

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

        public int X_coord
        {
            get
            { return x_cord;  }
            set
            { x_cord = value;  }
        }

        public void Sta(string receivedName, int y, int x)
        {
            name = receivedName;
            x_cord = x;
            y_cord = y;
        }

        

        //public void calcdistance()
        //{
        //    for (int i = 0; i < distanceresult.Count; i++)
        //    {
        //        int x0 = Convert.ToInt32(stations.station_x[i]);
        //        int y0 = Convert.ToInt32(stations.station_y[i]);

        //        int x1 = Convert.ToInt32(stations.station_x[i + 1]);
        //        int y1 = Convert.ToInt32(stations.station_y[i + 1]);

        //        int dX = x1 - x0;
        //        int dY = y1 - y0;
        //        double distance = Math.Sqrt(dX * dX + dY * dY);
        //    }

        //}

    }
}