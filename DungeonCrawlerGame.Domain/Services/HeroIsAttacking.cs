using DungeonCrawlerGame.Data;
using DungeonCrawlerGame.Data.Models.Heroes;
using DungeonCrawlerGame.Data.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Domain.Services
{
    public static class HeroIsAttacking
    {
        public static void WarriorAttack(Warrior myWarrior, Monster monster)
        {
            if (myWarrior.CanRageAttack()) {
                Console.WriteLine("I can rage attack monster and cause him double damage");
            var attackStrategy = " ";
                do
                {
                    Console.WriteLine("Please type 'RAGE' and I will go for rage attack if it is possible, if not I will just attack");
                    attackStrategy = Console.ReadLine();
                } while (String.IsNullOrEmpty(attackStrategy));
                if (attackStrategy.ToLower().Equals("rage"))
                    myWarrior.RageAttack(monster);
                else
                    myWarrior.Attack(monster);
            }
            else
                myWarrior.Attack(monster);
        }
        public static void MageAttack(Mage myMage, Monster monster)
        {
            if (myMage.CanRenewHPForMana())
            {
                Console.WriteLine($"I can use {StartValues.ManaConsumptionForRenewingHP} units of Mana for renew my HP!");
                var useManaForRenewingHP = " ";
                do
                {
                    Console.WriteLine("Please type 'MANA' and I will renew my HP!");
                    useManaForRenewingHP = Console.ReadLine();
                } while (String.IsNullOrEmpty(useManaForRenewingHP));
                if (useManaForRenewingHP.ToLower().Equals("mana"))
                    myMage.RenewHPForMana();
                else
                    myMage.Attack(monster);
            }
            else
                myMage.Attack(monster);
        }
        public static void RangerAttack(Ranger myRanger, Monster monster)
        {
            myRanger.CritStunAttack(monster);
        }
    }


}
