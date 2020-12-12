using DungeonCrawlerGame.Data.Models.Heroes;
using DungeonCrawlerGame.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models.Monsters
{
    public class Brute : Monster
    {
        public Brute()
        {
            MaxHealthPoints = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundBruteHP, StartValues.UpperBoundBruteHP);
            Damage = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundBruteDamage, StartValues.UpperBoundBruteDamage);
            HealthPoints = MaxHealthPoints;
            Experience = StartValues.ExperienceFromDefeatedBrute;
        }
        public override void Attack(Being hero)
        {
            if (RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundRandomGenerator,StartValues.UpperBoundRandomGenerator) < 50)
                hero.BeAttacked((int) (0.5 * hero.HealthPoints));
            else
                hero.BeAttacked(Damage);
        }
        public override string ToString()
        {
            return $"I am brute!\n" +
                $"{base.ToString()}";
        }
    }
}
