using System;
using System.Collections.Generic;
using System.Text;
using DungeonCrawlerGame.Data.Enums;

namespace DungeonCrawlerGame.Domain.Services
{
    public static class BattleService
    {
        public static void Round()
        {
            for(var i = 0; i <3; i++)
            {
                Console.WriteLine(Data.Enums.AttackType.DirectAttack);
            }
        }
    }
}
