using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models.Monsters
{
    public class Monster : Being
    {
        public int Experience { get; set; }
        public bool IsStunned { get; set; } = false;
        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"Experience:{Experience}\n" +
                $"Is stunned:{IsStunned}";
        }
        public virtual string MonsterType()
        {
            return "monster!";
        }
    }
}
