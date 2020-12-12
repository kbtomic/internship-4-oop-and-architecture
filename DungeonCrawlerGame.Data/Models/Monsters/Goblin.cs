using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models.Monsters
{
    public class Goblin : Monster
    {
        public Goblin()
        {
            MaxHealthPoints = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundGoblinHP, StartValues.UpperBoundGoblinHP);
            Damage = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundGoblinDamage, StartValues.UpperBoundGoblinDamage);
            HealthPoints = MaxHealthPoints;
            Experience = StartValues.ExperienceFromDefeatedGoblin;
        }
        public override string ToString()
        {
            return $"I am goblin!\n" +
                $"{base.ToString()}";
        }
    }
}
