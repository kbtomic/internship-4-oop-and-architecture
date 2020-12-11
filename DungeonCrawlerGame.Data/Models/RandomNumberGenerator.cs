using DungeonCrawlerGame.Data.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models
{
    public static class RandomNumberGenerator
    {
        public static int GenerateInRange(int lowerBound, int higherBound)
        {
            var random = new Random();
            var randomNumberInRange = random.Next(lowerBound, higherBound);
            return randomNumberInRange;
        }
        public static Monster GenerateMonster()
        {
            var randomNumber = GenerateInRange(StartValues.LowerBoundRandomGenerator, StartValues.UpperBoundRandomGenerator);
            if (randomNumber <= 70 && randomNumber >= 0)
                return new Goblin();
            else if (randomNumber <= 95 && randomNumber >= 71)
                return new Brute();
            else
                return new Witch();
        }
    }
}
