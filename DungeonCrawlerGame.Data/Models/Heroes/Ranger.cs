using DungeonCrawlerGame.Data.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models.Heroes
{
    public class Ranger : Hero
    {
        public Ranger()
        {
            MaxHealthPoints = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundRangerHP, StartValues.UpperBoundRangerHP);
            Damage = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundRangerDamage, StartValues.UpperBoundRangerDamage);
            HealthPoints = MaxHealthPoints;
        }
        public void CritStunAttack(Monster monster)
        {
            if (IsCriticalChance() && IsDoubleDamage())
            {
                monster.BeAttacked(Damage * 2);
                ValuesWhenMonsterIsDefeated(monster);
            }
            else if (IsStunChance() && IsMonsterStunned())
            {
                monster.IsStunned = true;
            }
            else
            {
                Attack(monster);
                ValuesWhenMonsterIsDefeated(monster);
            }
        }
        public bool IsCriticalChance()
        {
            return (RandomNumberGenerator.GenerateInRange(CurrentLevel, MaxLevel + 2).Equals(MaxLevel));
        }
        public bool IsDoubleDamage()
        {
            return (RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundRandomGenerator, StartValues.UpperBoundRandomGenerator) < StartValues.ProbabilityPercentage);
        }
        public bool IsStunChance()
        {
            return (RandomNumberGenerator.GenerateInRange(CurrentLevel, MaxLevel + 3).Equals(MaxLevel));
        }
        public bool IsMonsterStunned()
        {
            return (RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundRandomGenerator, StartValues.UpperBoundRandomGenerator) < StartValues.ProbabilityPercentage);
        }
        public override string ToString()
        {
            return $"I am ranger!\n" +
                $"{base.ToString()}";
        }
    }
}
