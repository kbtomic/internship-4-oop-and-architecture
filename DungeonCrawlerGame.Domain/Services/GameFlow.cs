using DungeonCrawlerGame.Data.Models;
using DungeonCrawlerGame.Data.Models.Heroes;
using DungeonCrawlerGame.Data.Models.Monsters;
using DungeonCrawlerGame.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Domain.Services
{
    public static class GameFlow
    {
        public static void Start()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the Dungeon Crawler game!");
            var myHero = HeroAndMonstersFactory.ChooseHeroType();
            var monsters = HeroAndMonstersFactory.GenerateMonsters();
            for (var i = 0; i < monsters.Count; i++)
            {
                BattleService.Battle(myHero, monsters[i], monsters);
                if(monsters[i].IsDead)
                {
                    Console.WriteLine("If you want to use 50% of your experience points to renew your HP type 'yes'!");
                    var confirmation = " ";
                    do {
                        confirmation = Console.ReadLine();
                    } while (String.IsNullOrEmpty(confirmation));
                    if (confirmation.ToLower().Equals("yes"))
                    {
                        myHero.Experience -= (int)(0.5 * myHero.Experience);
                        myHero.HealthPoints = myHero.MaxHealthPoints;
                        Console.WriteLine("HP renewed!");
                        GameStatistics.PrintStats(myHero, monsters[i], monsters);
                    }
                }
                if (monsters[i].IsDead && monsters[i] is Witch)
                {
                    monsters.Insert(i + 1, RandomNumberGenerator.GenerateMonster());
                    monsters.Insert(i + 2, RandomNumberGenerator.GenerateMonster());
                }
                else if (myHero.IsDead)
                {
                    if (myHero is Mage mage)
                    {
                        if (mage.Respawn())
                        {
                            Console.WriteLine("I am respawning!");
                            myHero.IsDead = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You are DEAD!!!");
                        break;
                    }

                }
            }
            Console.WriteLine("You won!!!");
        }
        public static bool End()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("This is the end of your journey my pal!");
            Console.WriteLine("If you want to start your journey again please type 'yes'!");
            var confirmation = " ";
            do
            {
                confirmation = Console.ReadLine();
            } while (String.IsNullOrEmpty(confirmation));
            if (confirmation.ToLower().Equals("yes"))
                return false;
            return true;
        }
    }
}
