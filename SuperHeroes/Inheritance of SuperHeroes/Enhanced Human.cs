using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_of_SuperHeroes
{
    class Enhanced_Human : SuperHero
    {
        int sumOfPowers;
        bool enhanced = false;
        private List<SuperPower> powerSet;

        public Enhanced_Human(string name, string secretId, List<SuperPower> myPowers)
        {
            foreach (int power in powerSet)
            {
                sumOfPowers++;
            }

            base.SwitchIdentity();

            
        }

        public SwitchIdentity()
        {

        }

        public override bool HasPower(SuperPower whatPower)
        {
            if ((enhanced == true) & (powerSet.Contains(whatPower)))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public override int TotalPower()
        {

        }

    }
}
