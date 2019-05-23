using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Properties
    {
        public string LocationName { get; set; }
        public int Xaxis { get; set; }
        public int Yaxis { get; set; }
    }

    class getStation
    {
        private string LocationName;
        private int Xaxis;
        private int Yaxis;

        //temporary

        public string GetLocationName()
        {
            return LocationName;
        }

        public int GetXaxis()
        {
            return Xaxis;
        }

        public int GetYaxis()
        {
            return Yaxis;
        }

        public getStation(string GetLocationName, int GetXaxis, int GetYaxis)
        {
            this.LocationName = GetLocationName;
            this.Xaxis = GetXaxis;
            this.Xaxis = GetXaxis;

        }

    }

}
