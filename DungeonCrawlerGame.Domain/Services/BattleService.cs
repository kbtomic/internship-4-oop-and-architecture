using System;
using System.Collections.Generic;
using System.Text;
using DungeonCrawlerGame.Data.Enums;
using DungeonCrawlerGame.Data.Models;
using DungeonCrawlerGame.Data.Models.Heroes;
using DungeonCrawlerGame.Data.Models.Monsters;
using DungeonCrawlerGame.Domain.Helpers;

namespace DungeonCrawlerGame.Domain.Services
{
    public static class BattleService
    {
        public static void Battle(Hero myHero, Monster monster, List<Monster> monsters)
        {
            while (!myHero.IsDead && !monster.IsDead)
            {
                if (!monster.IsDead)
                    GameStatistics.PrintStats(myHero, monster, monsters);
                var roundWinner = RoundWinner(myHero, monster);
                if (roundWinner is Warrior warrior)
                {
                    HeroIsAttacking.WarriorAttack(warrior, monster);
                }
                else if (roundWinner is Mage mage)
                {
                    HeroIsAttacking.MageAttack(mage, monster);
                }
                else if (roundWinner is Ranger ranger)
                {
                    HeroIsAttacking.RangerAttack(ranger, monster);
                }
                else if (roundWinner is Goblin goblin)
                {
                    MonsterIsAttacking.GoblinAttack(myHero, goblin);
                }
                else if (roundWinner is Brute brute)
                {
                    MonsterIsAttacking.BruteAttack(myHero, brute);
                }
                else if (roundWinner is Witch witch)
                {
                    MonsterIsAttacking.WitchAttack(myHero, witch, monsters);
                }
            }
        }
        public static Being RoundWinner(Hero myHero, Monster monster)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if(monster.IsStunned)
            {
                monster.IsStunned = false;
                Console.WriteLine("You won this round because monster is stunned!");
                return myHero;
            }

            Console.WriteLine("Enter '0' for direct attack, '1' for side attack, '2' for counter attack");
            var heroStrategySuccess = int.TryParse(Console.ReadLine(), out var heroStrategy);
            while(!heroStrategySuccess || (heroStrategy != (int)AttackType.DirectAttack && heroStrategy != (int)AttackType.SideAttack 
                && heroStrategy != (int)AttackType.CounterAttack))
            {
                Console.WriteLine("Enter '0' for direct attack, '1' for side attack, '2' for counter attack");
                heroStrategySuccess = int.TryParse(Console.ReadLine(), out heroStrategy);
            }
            var heroStrategyAsAttackType = (AttackType)heroStrategy;
            var monsterStrategyAsAttackType = (AttackType)RandomNumberGenerator.GenerateInRange((int)AttackType.DirectAttack, (int)AttackType.CounterAttack + 1);
            if (heroStrategyAsAttackType == AttackType.DirectAttack && monsterStrategyAsAttackType == AttackType.SideAttack)
            {
                Console.WriteLine("You won this round so you are attacking!\n");
                return myHero;
            }
            else if (heroStrategyAsAttackType == AttackType.SideAttack && monsterStrategyAsAttackType == AttackType.CounterAttack)
            {
                Console.WriteLine("You won this round so you are attacking!\n");
                return myHero;
            }
            else if (heroStrategyAsAttackType == AttackType.CounterAttack && monsterStrategyAsAttackType == AttackType.DirectAttack)
            {
                Console.WriteLine("You won this round so you are attacking!\n");
                return myHero;
            }
            else if (heroStrategyAsAttackType == monsterStrategyAsAttackType)
            {
                Console.WriteLine("Tied!\n");
                return RoundWinner(myHero, monster);
            }
            Console.WriteLine("Monster won this round so defend yourself!\n");
            return monster;
            
        }
    }
}
