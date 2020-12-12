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
            do
            {
                GameFlow.Start();
            } while (!GameFlow.End());
            
        }
    }
}
