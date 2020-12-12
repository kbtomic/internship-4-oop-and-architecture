using DungeonCrawlerGame.Data.Models.Heroes;
using DungeonCrawlerGame.Data.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Domain.Helpers
{
    public static class GameStatistics
    {
        public static void PrintStats(Hero myHero, Monster currentMonster, List<Monster> monsters)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Current statistics:");
            Console.WriteLine(myHero.ToString());
            Console.WriteLine(currentMonster.ToString());
            Console.WriteLine($"Number of monsters remaining to defend:{monsters.Count - monsters.IndexOf(currentMonster)}\n");
        }
    }
}
