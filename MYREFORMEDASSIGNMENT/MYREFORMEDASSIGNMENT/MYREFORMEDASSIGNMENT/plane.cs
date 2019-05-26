using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MYREFORMEDASSIGNMENT
{
    public static class plane
    {
        public static double range;
        public static double speed;
        public static double takeoff;
        public static double landingtime;
        public static int refueltime;

        public static void readplanespecs(string planespec)
        {

            string[] planefilelines = File.ReadAllLines(planespec);
            new FileStream(planespec, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            FileStream planeinFile = new FileStream(planespec, FileMode.Open, FileAccess.Read);
            StreamReader planereader = new StreamReader(planeinFile);

            string planeline;
            string[] planeDetails;

            while ((planeline = planereader.ReadLine()) != null)
            {
                //range speed take-off-time landing-time refuel-time
                //3     300     3               3           10

                planeDetails = planeline.Split(' ');

                range = double.Parse(planeDetails[0]) * 60;
                speed = double.Parse(planeDetails[1]);
                takeoff = double.Parse(planeDetails[2]);
                landingtime = double.Parse(planeDetails[3]);
                refueltime = int.Parse(planeDetails[4]);
            }

            planereader.Close();
            planeinFile.Close();

        }
    }

}
