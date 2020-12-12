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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to the Dungeon Crawler game!");
            do
            {
                GameFlow.Start();
            } while (!GameFlow.End());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Goodbye!");
        }
    }
}
