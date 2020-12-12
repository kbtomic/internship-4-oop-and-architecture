using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models.Monsters
{
    public class Witch : Monster
    {
        public Witch()
        {
            MaxHealthPoints = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundWitchHP, StartValues.UpperBoundWitchHP);
            Damage = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundWitchDamage, StartValues.UpperBoundWitchDamage);
            HealthPoints = MaxHealthPoints;
            Experience = StartValues.ExperienceFromDefeatedWitch;
        }
        public bool IsDumbusAttack()
        {
            return (RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundRangerDamage, StartValues.UpperBoundRandomGenerator) < StartValues.ProbabilityPercentage);
        }
   
        public override string ToString()
        {
            return $"I am witch!\n" +
                $"{base.ToString()}";
        }
    }
}
