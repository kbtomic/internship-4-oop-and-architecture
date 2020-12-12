using DungeonCrawlerGame.Data;
using DungeonCrawlerGame.Data.Models;
using DungeonCrawlerGame.Data.Models.Heroes;
using DungeonCrawlerGame.Data.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Domain.Services
{
    public static class MonsterIsAttacking
    {
        public static void GoblinAttack(Hero myHero, Goblin monster)
        {
            monster.Attack(myHero);
        }
        public static void BruteAttack(Hero myHero, Brute monster)
        {
            monster.Attack(myHero);
        }
        public static void WitchAttack(Hero myHero, Witch monster, List<Monster> monsters)
        {
            if(monster.IsDumbusAttack())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Dumbus attack!!!");
                myHero.HealthPoints = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundHP, StartValues.UpperBoundHP);
                myHero.MaxHealthPoints = myHero.HealthPoints;
                for (var i = 0; i < monsters.Count; i++)
                {
                    monsters[i].HealthPoints = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundHP, StartValues.UpperBoundHP);
                    monsters[i].MaxHealthPoints = monsters[i].HealthPoints;
                }
            }
            else
                monster.Attack(myHero);

        }
    }
}
