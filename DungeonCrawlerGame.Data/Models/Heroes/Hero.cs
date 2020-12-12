using DungeonCrawlerGame.Data.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models.Heroes
{
    public class Hero : Being
    {
        public string Name { get; set; }
        public int Experience { get; set; } = 0;
        public int ExperienceToNextLevel { get; set; } = 50;
        public int CurrentLevel { get; set; } = 1;
        public int MaxLevel { get; set; } = 5;
        public void LevelUp()
        {
            if (Experience > ExperienceToNextLevel)
            {
                if(CurrentLevel < MaxLevel)
                    CurrentLevel++;
                Experience = Experience - ExperienceToNextLevel;
                HealthPoints += StartValues.LevelUpHP;
                if (HealthPoints > MaxHealthPoints)
                    HealthPoints = MaxHealthPoints;
                Damage += StartValues.LevelUpDamage;
                if (Damage > StartValues.UpperBoundDamage)
                    Damage = StartValues.UpperBoundDamage;
            }
        }
        public void ValuesWhenMonsterIsDefeated(Monster monster)
        {
            if (monster.IsDead)
            {
                Experience += monster.Experience;
                HealthPoints += (int)(0.25 * MaxHealthPoints);
                if (HealthPoints > StartValues.UpperBoundHP)
                    HealthPoints = MaxHealthPoints;
                LevelUp();
            }
        }
        public override string ToString()
        {
            return $"Hero name:{Name}\n" +
                $"{base.ToString()}" +
                $"Experience:{Experience}\n" +
                $"Experience to next level:{ExperienceToNextLevel}\n" +
                $"Current level: {CurrentLevel}\n" +
                $"Max level: {MaxLevel}\n";
        }
    }
}
