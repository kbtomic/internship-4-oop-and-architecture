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
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine(Data.Enums.AttackType.CounterAttack.ToString());
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the Dungeon Crawler game!");
            var myHero = Game.ChooseHeroType();
            Game.ChooseHeroName(myHero);
            Game.HeroStartValues(myHero);
        }
    }
}
