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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Current statistics:\n");
            Console.WriteLine(myHero.ToString());
            Console.WriteLine("Current monster: ");
            Console.WriteLine(currentMonster.ToString());
            Console.WriteLine($"Number of monsters remaining to attack:{monsters.Count - monsters.IndexOf(currentMonster)}\n");
        }
    }
}
