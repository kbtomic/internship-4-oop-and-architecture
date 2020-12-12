using DungeonCrawlerGame.Data.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models.Heroes
{
    public class Warrior : Hero
    {
        public Warrior()
        {
            MaxHealthPoints = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundWarriorHP, StartValues.UpperBoundWarriorHP);
            Damage = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundWarriorDamage, StartValues.UpperBoundWarriorDamage);    
            HealthPoints = MaxHealthPoints;
        }
        public bool CanRageAttack()
        {
            return (HealthPoints >= (int)(0.2 * MaxHealthPoints) + 1);
        }
        public void RageAttack(Monster monster)
        {
            if (CanRageAttack())
            {
                Console.WriteLine("Rage attacking grrrr!!!");
                HealthPoints = (int)(HealthPoints - 0.2 * MaxHealthPoints);
                monster.BeAttacked(Damage * 2);
            }
            ValuesWhenMonsterIsDefeated(monster);
        }
        public override string ToString()
        {
            return $"I am warrior!\n" +
                $"{base.ToString()}";
        }

    }                     
}
