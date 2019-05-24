using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment
{
    class Tour
    {
        private string name;
        private int x;
        private int y;

        public string Name { get => name; set => name = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Tour(string name, int x, int y)
        {
            this.Name = name;
            this.X = Convert.ToInt32(x);
            this.Y = Convert.ToInt32(y);
        }
    }

    class TourListing
    {
        private static List<Tour> TourList = new List<Tour>();

        static StationListing ListStation = new StationListing();

        public List<Tour> GetTourList(string fileName)
        {
            List<Station> S = ListStation.GetStationList(fileName);

            TourList.Add(new Tour(S[0].Name, S[0].X, S[0].Y));

            TourList.Add(new Tour(S[1].Name, S[1].X, S[1].Y));

            TourList.Add(new Tour(S[0].Name, S[0].X, S[0].Y));

            double Impact;
            string name = "null";
            int index = 0;
            var x = 0;
            var y = 0;

            for (int i = 2; i < S.Count; i++)
            {
                double minVal = 1000000;

                for (int j = 1; j < TourList.Count; j++)
                {
                    Impact = Distance.DistanceCalcST(S[i], TourList[j - 1])
                        + Distance.DistanceCalcST(S[i], TourList[j])
                        - Distance.DistanceCalcTT(TourList[j], TourList[j - 1]);

                    if (Impact <= minVal)
                    {
                        minVal = Impact;
                        name = S[i].Name;
                        x = S[i].X;
                        y = S[i].Y;
                        index = j;
                    }

                }
                TourList.Insert(index, new Tour(name, x, y));
                minVal = 1000000;
            }
            return TourList;
        }
    }

    class Distance
    {
        public static double DistanceCalcST(Station stationOne, Tour tourTwo)
        {
            int x1 = stationOne.X; int x2 = tourTwo.X;
            int y1 = stationOne.Y; int y2 = tourTwo.Y;

            double Ed = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
            double roundEd = Math.Round(Ed, 4);
            return roundEd;
        }

        public static double DistanceCalcTT(Tour tourOne, Tour tourTwo)
        {
            int x1 = tourOne.X; int x2 = tourTwo.X;
            int y1 = tourOne.Y; int y2 = tourTwo.Y;

            double Ed = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
            double roundEd = Math.Round(Ed, 4);
            return roundEd;
        }
    }
}
