using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models.Heroes
{
    public class Hero : Being
    {
        public string Name { get; set; }
        public int Experience { get; set; } = 0;
        public int ExperienceToNextLevel { get; set; } = 100;
        public int CurrentLevel { get; set; } = 1;
        public int MaxLevel { get; set; } = 5;
        public bool LevelUp()
        {
            if (Experience > ExperienceToNextLevel)
            {
                CurrentLevel++;
                Experience = Experience - ExperienceToNextLevel;
                HealthPoints += StartValues.LevelUpHP;
                if (HealthPoints > MaxHealthPoints)
                    HealthPoints = MaxHealthPoints;
                Damage += StartValues.LevelUpDamage;
                if (Damage > StartValues.UpperBoundDamage)
                    Damage = StartValues.UpperBoundDamage;
                return true;
            }
            else
                return false;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
