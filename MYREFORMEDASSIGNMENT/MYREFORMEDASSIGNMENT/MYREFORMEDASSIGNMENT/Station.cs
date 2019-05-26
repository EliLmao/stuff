using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MYREFORMEDASSIGNMENT
{
    class Station
    {
        private string name;
        private int x;
        private int y;

        public Station(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public string Name { get => name; set => name = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }

    class StationListing
    {
        private List<Station> StationList = new List<Station>();

        public List<Station> GetStationList(string fileName)
        {
            char space = ' ';

            FileStream inFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            string recordIn;
            string[] coord;
            recordIn = reader.ReadLine();

            for (int i = 0; recordIn != null; i++)
            {
                coord = recordIn.Split(space);
                StationList.Add(new Station(coord[0], Convert.ToInt32(coord[1]), Convert.ToInt32(coord[2])));
                recordIn = reader.ReadLine();
            }

            inFile.Close();
            reader.Close();

            return StationList;

        }

        internal List<Station> GetStationList()
        {
            throw new NotImplementedException();
        }
    }
}
