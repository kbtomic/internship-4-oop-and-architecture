using System;
using DungeonCrawlerGame.Data.Models;
using DungeonCrawlerGame.Data.Enums;
using DungeonCrawlerGame.Domain.Services;


namespace DungeonCrawlerGame.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the Dungeon Crawler game!");
            var myHero = StartGame.ChooseHeroType();
            var monsters = StartGame.GenerateMonsters();
            BattleService.RoundWinner(myHero, monsters[0]);
            
        }
    }
}
