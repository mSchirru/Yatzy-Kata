using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Yatzy
    {
        protected int[] dices;

        public Yatzy(int dice1, int dice2, int dice3, int dice4, int dice5)
        {
            dices = new int[5];
            dices[0] = dice1;
            dices[1] = dice2;
            dices[2] = dice3;
            dices[3] = dice4;
            dices[4] = dice5;
        }

        public int Chance()
        {
            var sum = 0;
            for (int i = 0; i < dices.Length; i++)
            {
                sum += dices[i];
            }
            return sum;
        }

        public int CheckForYatzy()
        {
            var duplicates = GetNumberOfDuplicates();
            if (duplicates.Any(KeyValue => KeyValue.Value == 5))
            {
                return 50;
            }
            else
            {
                return 0;
            }

        }

        public int CheckForSingleValue(int dicesValue)
        {
            int numberOfReps = 0;
            foreach (var dice in dices)
            {
                if (dice == dicesValue)
                {
                    numberOfReps++;
                }
            }
            return numberOfReps * dicesValue;
        }

        public int Ones() => CheckForSingleValue(1);
        public int Twos() => CheckForSingleValue(2);
        public int Threes() => CheckForSingleValue(3);
        public int Fours() => CheckForSingleValue(4);
        public int Fives() => CheckForSingleValue(5);
        public int Sixes() => CheckForSingleValue(6);

        public int CheckForElementsOfAKind(int numberOfElements)
        {
            var duplicates = GetNumberOfDuplicates();
            var highestValue = duplicates.Aggregate((l, r) => l.Value > r.Value ? l : r);

            if (highestValue.Value >= numberOfElements)
            {
                return highestValue.Key * numberOfElements;
            }
            else
            {
                return 0;
            }
        }
        public Dictionary<int, int> GetNumberOfDuplicates()
        {
            return dices.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        }

        public int ThreeOfAKind() => CheckForElementsOfAKind(3);
        public int FourOfAKind() => CheckForElementsOfAKind(4);

        public int CheckForPairs(int numberOfPairs)
        {
            var sum = 0;
            var duplicates = GetNumberOfDuplicates();
            var dicesWithDuplicatedValues = duplicates.Where(KeyValue=> KeyValue.Value >= 2).OrderByDescending(KeyValue=> KeyValue.Key);
            
            if (dicesWithDuplicatedValues.Count() >= numberOfPairs)
            {
                for (var i = 0; i < numberOfPairs; i++)
                {
                    sum += dicesWithDuplicatedValues.ElementAt(i).Key * 2;
                }
            }
            else
            {
                return sum;
            }
            return sum;
        }

        public int ScorePair() => CheckForPairs(1);
        public int TwoPair() => CheckForPairs(2);

        public int SmallStraight()
        {
            if (dices.Distinct().Count() == dices.Length && dices.Contains(1) && !dices.Contains(6))
            {
                return 15;
            }
            return 0;
        }

        public int LargeStraight()
        {
            if (dices.Distinct().Count() == dices.Length && dices.Contains(6) && !dices.Contains(1))
            {
                return 20;
            }
            return 0;
        }

        public int FullHouse()
        {
            
            var duplicates = GetNumberOfDuplicates().Where(KeyValue=> KeyValue.Value >= 2);
            if (duplicates.Count() == 2 && duplicates.Sum(KeyValue=> KeyValue.Value) == 5)
            {

                return duplicates.Sum(KeyValue => KeyValue.Key * KeyValue.Value) ;
            }
            else
            {
                return 0;
            }
        }
    }
}