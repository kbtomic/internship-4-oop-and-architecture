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
            Console.ForegroundColor = ConsoleColor.Red;
            var myHero = HeroAndMonstersFactory.ChooseHeroType();
            var monsters = HeroAndMonstersFactory.GenerateMonsters();
            for (var i = 0; i < monsters.Count; i++)
            {
                BattleService.Battle(myHero, monsters[i], monsters);
                if(monsters[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Bye bye {monsters[i].MonsterType()}");
                    GameStatistics.PrintStats(myHero, monsters[i + 1], monsters);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("If you want to use 50% of your experience points to renew your HP type 'yes'!");
                    var confirmation = " ";
                    do {
                        confirmation = Console.ReadLine();
                    } while (String.IsNullOrEmpty(confirmation));
                    if (confirmation.ToLower().Equals("yes"))
                    {
                        myHero.Experience -= (int)(0.5 * myHero.Experience);
                        myHero.HealthPoints = myHero.MaxHealthPoints;
                        Console.WriteLine("HP renewed!\n");
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
                            Console.WriteLine("I am respawning!\n");
                            myHero.IsDead = false;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You are DEAD!!!");
                        break;
                    }

                }
            }
            if (!myHero.IsDead)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You are WINNER!!!");
            }
        }
        public static bool End()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is the end of the game my pal!");
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
