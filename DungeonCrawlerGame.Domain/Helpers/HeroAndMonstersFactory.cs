using DungeonCrawlerGame.Data.Models.Heroes;
using DungeonCrawlerGame.Data;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonCrawlerGame.Data.Models.Monsters;
using DungeonCrawlerGame.Data.Models;

namespace DungeonCrawlerGame.Domain.Helpers
{
    public static class HeroAndMonstersFactory
    {
        public static Hero ChooseHeroType()
        {
            var heroName = " ";
            do
            {
                Console.WriteLine("Please enter name of your hero!");
                heroName = Console.ReadLine();
            } while (String.IsNullOrEmpty(heroName));

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Warrior has the highest HP and the lowest Damage! " +
                "It can rage attack the monster - for cost of 20% HP it causes double damage to monster!\n");
            Console.WriteLine("Mage has the lowest HP and the biggest Damage! " +
                "It has special ability - MANA and also can respawn once!\n");
            Console.WriteLine("Ranger has medium HP and Damage! " +
                "It has two special abilities - critical chance and stun chance!\n");

            
            var heroType = " ";
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Choose type of your hero - warrior, mage or ranger!");
                heroType = Console.ReadLine();
                if (heroType.ToLower().Equals("warrior"))
                {
                    var myHero = new Warrior();
                    UserInputHeroHP(myHero);
                    myHero.Name = heroName;
                    return myHero;
                }
                else if (heroType.ToLower().Equals("mage"))
                {
                    var myHero = new Mage();
                    UserInputHeroHP(myHero);
                    myHero.Name = heroName;
                    return myHero;
                }
                else if (heroType.ToLower().Equals("ranger"))
                {
                    var myHero = new Ranger();
                    UserInputHeroHP(myHero);
                    myHero.Name = heroName;
                    return myHero;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("That hero type does not exist!");
                }
            } while (String.IsNullOrEmpty(heroType) || !heroType.ToLower().Equals("warrior") || !heroType.ToLower().Equals("mage")
                            || !heroType.ToLower().Equals("ranger"));
            return null;

        }
     
        public static void UserInputHeroHP(Hero myHero)
        {
            Console.WriteLine("If you want to choose HP for your hero type 'yes', or I will do it for you he he!");
            var playerChooseHP = Console.ReadLine();
            if(playerChooseHP.Equals("yes"))
            {
                Console.WriteLine("Please enter amount of HP for your hero, but be careful, hero CAN'T have more than 100 HP!");
                var chosenHPSuccess = int.TryParse(Console.ReadLine(), out int chosenHP);
                while (!chosenHPSuccess || chosenHP > StartValues.UpperBoundHP || chosenHP < StartValues.LowerBoundHP)
                {
                    Console.WriteLine("Please enter amount of HP for your hero, but be careful, hero CAN'T have more than 100 HP!");
                    chosenHPSuccess = int.TryParse(Console.ReadLine(), out chosenHP);
                }
                myHero.MaxHealthPoints = chosenHP;
                myHero.HealthPoints = chosenHP;
            }
        }
        public static List<Monster> GenerateMonsters()
        {
            var monsters = new List<Monster>();
            for(var i = 0; i < 10; i++)
                monsters.Add(RandomNumberGenerator.GenerateMonster());
            return monsters;
        }

    }
}
