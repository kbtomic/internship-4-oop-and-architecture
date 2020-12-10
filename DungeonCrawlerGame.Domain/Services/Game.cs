using DungeonCrawlerGame.Data.Models.Heroes;
using DungeonCrawlerGame.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Domain.Services
{
    public static class Game
    {
        public static Hero ChooseHeroType()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Warrior has the highest HP and the lowest Damage! " +
                "It can rage attack the monster - for cost of 20% HP it causes double damage to monster!");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Mage has the lowest HP and the biggest Damage! " +
                "It has special ability - MANA and also can respawn once!");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Ranger has medium HP and Damage! " +
                "It has two special abilities - critical chance and stun chance!");

            Console.WriteLine("Choose type of your hero - warrior, mage or ranger!");
            var heroType = Console.ReadLine();
            do
            {
                heroType = Console.ReadLine();
                if(heroType.ToLower().Equals("warrior"))
                    return new Warrior();
                else if (heroType.ToLower().Equals("mage"))
                    return new Mage();
                else if (heroType.ToLower().Equals("ranger"))
                    return new Ranger();
                else
                {
                    Console.WriteLine("Please enter correct type!");
                }
            } while (String.IsNullOrEmpty(heroType) || !heroType.ToLower().Equals("warrior") || !heroType.ToLower().Equals("mage")
                            || !heroType.ToLower().Equals("ranger"));
            return null;

        }
        public static void ChooseHeroName(Hero myHero)
        {
            Console.WriteLine("Please enter hero name!");
            var heroName = Console.ReadLine();
            do
            {
                heroName = Console.ReadLine();
            } while (String.IsNullOrEmpty(heroName));
            myHero.Name = heroName;
        }
        public static void HeroStartValues(Hero myHero)
        {
            Console.WriteLine("If you want to choose HP of your hero type 'yes', else the game will do it for you!");
            var playerChooseHP = Console.ReadLine();
            if (myHero is Warrior)
            {
                if(playerChooseHP.Equals("yes"))
                {
                    Console.WriteLine("Enter how many HP your hero has: <100!");
                    var chosenHPSuccess = int.TryParse(Console.ReadLine(), out int chosenHP);
                    while(!chosenHPSuccess || chosenHP > 100)
                        chosenHPSuccess = int.TryParse(Console.ReadLine(), out chosenHP);
                    myHero.MaxHealthPoints = chosenHP;
                }
                else
                    myHero.MaxHealthPoints = Data.Models.RandomNumberGenerator.GenerateInRange(Data.StartValues.LowerBoundWarriorHP, Data.StartValues.UpperBoundWarriorHP);
                myHero.Damage = Data.Models.RandomNumberGenerator.GenerateInRange(Data.StartValues.LowerBoundWarriorDamage, Data.StartValues.UpperBoundWarriorDamage);
            }
            else if (myHero is Mage)
            {
                if (playerChooseHP.Equals("yes"))
                {
                    Console.WriteLine("Enter how many HP your hero has: <100!");
                    var chosenHPSuccess = int.TryParse(Console.ReadLine(), out int chosenHP);
                    while (!chosenHPSuccess || chosenHP > 100)
                        chosenHPSuccess = int.TryParse(Console.ReadLine(), out chosenHP);
                    myHero.MaxHealthPoints = chosenHP;
                }
                else
                    myHero.MaxHealthPoints = Data.Models.RandomNumberGenerator.GenerateInRange(Data.StartValues.LowerBoundMageHP, Data.StartValues.UpperBoundMageHP);
                myHero.Damage = Data.Models.RandomNumberGenerator.GenerateInRange(Data.StartValues.LowerBoundMageDamage, Data.StartValues.UpperBoundMageDamage);
            }
            else if (myHero is Ranger)
            {
                if (playerChooseHP.Equals("yes"))
                {
                    Console.WriteLine("Enter how many HP your hero has: <100!");
                    var chosenHPSuccess = int.TryParse(Console.ReadLine(), out int chosenHP);
                    while (!chosenHPSuccess || chosenHP > 100)
                        chosenHPSuccess = int.TryParse(Console.ReadLine(), out chosenHP);
                    myHero.MaxHealthPoints = chosenHP;
                }
                else
                    myHero.MaxHealthPoints = Data.Models.RandomNumberGenerator.GenerateInRange(Data.StartValues.LowerBoundRangerHP, Data.StartValues.UpperBoundRangerHP);
                myHero.Damage = Data.Models.RandomNumberGenerator.GenerateInRange(Data.StartValues.LowerBoundRangerDamage, Data.StartValues.UpperBoundRangerDamage);
            }
        }
    }
}
