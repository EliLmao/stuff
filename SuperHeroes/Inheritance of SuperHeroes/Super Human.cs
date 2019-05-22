using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_of_SuperHeroes {
    class Super_Human : SuperHero {

        private int sumOfPowers;
        private List<SuperPower> powerSet;
        private List<SuperPower> originalPowers;
        private int originalSumOfPowers;

        public Super_Human(string name, string secretId, List<SuperPower> myPowers)
            : base(name, secretId) {
            sumOfPowers = 0;
            powerSet = myPowers;
            originalPowers = powerSet;

            foreach (SuperPower power in powerSet) {
                sumOfPowers += (int)power;
            }
            originalSumOfPowers = sumOfPowers;
        }

        public override bool HasPower(SuperPower whatPower) {
            return powerSet.Contains(whatPower);
        }

        public override int TotalPower() {
            return sumOfPowers;
        }

        public void AddSuperPower(SuperPower newPower) {
            if (!powerSet.Contains(newPower)) {
                powerSet.Add(newPower);
                sumOfPowers += (int)newPower;
            }
        }

        public void LoseSinglePower(SuperPower power) {
            if (powerSet.Contains(power)) {
                powerSet.Remove(power);
                sumOfPowers -= (int)power;
            }
        }

        public void LoseAllSuperPowers() {
            powerSet.Clear();
            sumOfPowers = 0;
        }

        public void ResetPowers() {
            powerSet = originalPowers;
            sumOfPowers = originalSumOfPowers;
        }
    }
}
