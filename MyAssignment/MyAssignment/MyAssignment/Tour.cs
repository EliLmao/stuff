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
        private static List<Tour> FinalListOfTours = new List<Tour>();

        static StationListing ListStation = new StationListing();

        public List<Tour> GetTourList(string fileName)
        {
            Console.WriteLine("Optimising tour length: Level 1...");

            List<Station> FinalListOfStations = ListStation.GetStationList(fileName);

            FinalListOfTours.Add(new Tour(FinalListOfStations[0].Name, FinalListOfStations[0].X, FinalListOfStations[0].Y));

            FinalListOfTours.Add(new Tour(FinalListOfStations[1].Name, FinalListOfStations[1].X, FinalListOfStations[1].Y));

            FinalListOfTours.Add(new Tour(FinalListOfStations[0].Name, FinalListOfStations[0].X, FinalListOfStations[0].Y));

            double Difference;
            string tourName = "null";
            int x = 0;
            var X_coord = 0;
            var Y_coord = 0;

            for (int i = 2; i < FinalListOfStations.Count; i++)
            {
                double minimal = 1000000;

                for (int j = 1; j < FinalListOfTours.Count; j++)
                {
                    Difference = Distance.CalcStationDistance(FinalListOfStations[i], FinalListOfTours[j - 1]) + Distance.CalcStationDistance(FinalListOfStations[i], FinalListOfTours[j])
                        - Distance.CalcTourDistance(FinalListOfTours[j], FinalListOfTours[j - 1]);

                    if (Difference <= minimal)
                    {
                        minimal = Difference;
                        tourName = FinalListOfStations[i].Name;
                        X_coord = FinalListOfStations[i].X;
                        Y_coord = FinalListOfStations[i].Y;
                        x = j;
                    }

                }

                FinalListOfTours.Insert(x, new Tour(tourName, X_coord, Y_coord));
                minimal = 1000000;
            }
            return FinalListOfTours;
        }
    }

    class Distance
    {
        public static double CalcStationDistance(Station stationOne, Tour tourTwo)
        {
            int x1 = stationOne.X; int x2 = tourTwo.X;
            int y1 = stationOne.Y; int y2 = tourTwo.Y;

            double Ed = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
            double roundEd = Math.Round(Ed, 4);
            return roundEd;

            //int x0 = s0.X;
            //int y0 = s0.Y;

            //int x1 = s1.X;
            //int y1 = s1.Y;

            //int dX = x1 - x0;
            //int dY = y1 - y0;
            //double distance = Math.Sqrt(dX * dX + dY * dY);

            //return distance;
        }

        public static double CalcTourDistance(Tour tourOne, Tour tourTwo)
        {
            int x1 = tourOne.X; int x2 = tourTwo.X;
            int y1 = tourOne.Y; int y2 = tourTwo.Y;

            double Ed = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
            double roundEd = Math.Round(Ed, 4);
            return roundEd;
        }
    }
}
