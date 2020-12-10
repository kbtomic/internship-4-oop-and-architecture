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
        public override void Attack(Being monster)
        {
            if (IsCriticalChance() && IsDoubleDamage())
                    monster.BeAttacked(Damage * 2);
            else if (IsStunChance() && IsMonsterStunned())
            {

            }
            else
                monster.BeAttacked(Damage);
        }
        public bool IsCriticalChance()
        {
            return (RandomNumberGenerator.GenerateInRange(CurrentLevel, MaxLevel + 2).Equals(MaxLevel));
        }
        public bool IsDoubleDamage()
        {
            return (RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundRandomGenerator, StartValues.UpperBoundRandomGenerator) < 30);
        }
        public bool IsStunChance()
        {
            return (RandomNumberGenerator.GenerateInRange(CurrentLevel, MaxLevel + 3).Equals(MaxLevel));
        }
        public bool IsMonsterStunned()
        {
            return (RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundRandomGenerator, StartValues.UpperBoundRandomGenerator) < 30);
        }
    }
}
