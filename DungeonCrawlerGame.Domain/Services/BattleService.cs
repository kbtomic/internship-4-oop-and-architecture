using System;
using System.Collections.Generic;
using System.Text;
using DungeonCrawlerGame.Data.Enums;
using DungeonCrawlerGame.Data.Models;
using DungeonCrawlerGame.Data.Models.Heroes;
using DungeonCrawlerGame.Data.Models.Monsters;

namespace DungeonCrawlerGame.Domain.Services
{
    public static class BattleService
    {
        public static Being RoundWinner(Hero myHero, Monster monster)
        {
            Console.WriteLine("Enter '0' for direct attack, '1' for side attack, '2' for counter attack");
            var heroStrategySuccess = int.TryParse(Console.ReadLine(), out var heroStrategy);
            while(!heroStrategySuccess || !heroStrategy.Equals(Data.Enums.AttackType.DirectAttack) || !heroStrategy.Equals(Data.Enums.AttackType.SideAttack)
                                       || !heroStrategy.Equals(Data.Enums.AttackType.CounterAttack))
            {
                Console.WriteLine("Enter '0' for direct attack, '1' for side attack, '2' for counter attack");
                heroStrategySuccess = int.TryParse(Console.ReadLine(), out heroStrategy);
            }
            var monsterStrategy = RandomNumberGenerator.GenerateInRange((int)Data.Enums.AttackType.DirectAttack, (int)Data.Enums.AttackType.CounterAttack + 1);
            if (heroStrategy.Equals(Data.Enums.AttackType.DirectAttack) && monsterStrategy.Equals(Data.Enums.AttackType.SideAttack))
            {
                return myHero;
            }
            else if (heroStrategy.Equals(Data.Enums.AttackType.SideAttack) && monsterStrategy.Equals(Data.Enums.AttackType.CounterAttack))
            {
                return myHero;
            }
            else if (heroStrategy.Equals(Data.Enums.AttackType.CounterAttack) && monsterStrategy.Equals(Data.Enums.AttackType.DirectAttack))
            {
                return myHero;
            }
            else if (heroStrategy.Equals(monsterStrategy))
            {
                RoundWinner(myHero, monster);
            }
            else
            {
                return monster;
            }
            return null;


        }
    }
}
