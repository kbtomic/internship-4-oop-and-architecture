using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models
{
    public class Being
    {
        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public bool IsDead { get; set; } = false;
        public virtual void Attack(Being being)
        {
            being.BeAttacked(Damage);
        }
        public virtual void BeAttacked(int damage)
        {
            HealthPoints -= damage;
            if (HealthPoints <= 0)
            {
                HealthPoints = 0;
                IsDead = true;
            }
        }
        public override string ToString()
        {
            return $"Max health points:{MaxHealthPoints}\n" +
                $"Health points:{HealthPoints}\n" +
                $"Damage:{Damage}\n";
        }
    }
}
