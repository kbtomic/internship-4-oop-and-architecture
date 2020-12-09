using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models
{
    public class Being
    {
        public string Name { get; set; }
        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public virtual int Attack()
        {
            return 0;
        }
        public void BeAttacked(int damage)
        {
            HealthPoints -= damage;
            if (HealthPoints <= 0)
                Death();
        }
        public void Death()
        {

        }
    }
}
