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
        public void RageAttack(Monster monster)
        {
            if(HealthPoints >=(int)( 0.2 * MaxHealthPoints) + 1)
                HealthPoints = (int)(HealthPoints - 0.2 * MaxHealthPoints);
            monster.BeAttacked(Damage * 2);
        }
        public override void Attack(Being monster)
        {
            monster.BeAttacked(Damage);
        }

    }                     
}
