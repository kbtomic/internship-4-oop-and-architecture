using DungeonCrawlerGame.Data.Models.Heroes;
using DungeonCrawlerGame.Data;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonCrawlerGame.Data.Models.Monsters;
using DungeonCrawlerGame.Data.Models;
using DungeonCrawlerGame.Data.Enums;

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

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Choose type of your hero - '0' for warrior, '1' for mage or '2' for ranger!");
                var heroTypeSuccess = int.TryParse(Console.ReadLine(), out var heroType);
                while (!heroTypeSuccess || (heroType != (int)HeroType.Warrior && heroType != (int)HeroType.Mage && heroType != (int)HeroType.Ranger))
                {
                    Console.WriteLine("Choose type of your hero - '0' for warrior, '1' for mage or '2' for ranger!");
                    heroTypeSuccess = int.TryParse(Console.ReadLine(), out heroType);
                }
                var heroTypeAsHeroType = (HeroType)heroType;
                if (heroTypeAsHeroType == HeroType.Warrior)
                {
                    var myHero = new Warrior();
                    UserInputHeroHP(myHero);
                    myHero.Name = heroName;
                    return myHero;
                }
                else if (heroTypeAsHeroType == HeroType.Mage)
                {
                    var myHero = new Mage();
                    UserInputHeroHP(myHero);
                    myHero.Name = heroName;
                    return myHero;
                }
                else if (heroTypeAsHeroType == HeroType.Ranger)
                {
                    var myHero = new Ranger();
                    UserInputHeroHP(myHero);
                    myHero.Name = heroName;
                    return myHero;
                }
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
