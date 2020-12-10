using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data
{
    public static class StartValues
    {
        public static int UpperBoundRandomGenerator { get; set; } = 100;
        public static int LowerBoundRandomGenerator { get; set; } = 0;
        public static int UpperBoundHP { get; set; } = 100;
        public static int UpperBoundDamage { get; set; } = 100;
        public static int ManaConsumptionForAttacking { get; set; } = 2;
        public static int ManaConsumptionForRenewingHP { get; set; } = 10;

        public static int LowerBoundWarriorHP { get; set; } = 90;
        public static int UpperBoundWarriorHP { get; set; } = UpperBoundHP;
        public static int LowerBoundMageHP { get; set; } = 1;
        public static int UpperBoundMageHP { get; set; } = 30;
        public static int LowerBoundRangerHP { get; set; } = 31;
        public static int UpperBoundRangerHP { get; set; } = 89;

        public static int LowerBoundWarriorDamage { get; set; } = 1;
        public static int UpperBoundWarriorDamage { get; set; } = 30;
        public static int LowerBoundMageDamage { get; set; } = 90;
        public static int UpperBoundMageDamage { get; set; } = UpperBoundDamage;
        public static int LowerBoundRangerDamage { get; set; } = 31;
        public static int UpperBoundRangerDamage { get; set; } = 89;

        public static int LowerBoundGoblinHP { get; set; } = 1;
        public static int UpperBoundGoblinHP { get; set; } = 20;
        public static int LowerBoundBruteHP { get; set; } = 80;
        public static int UpperBoundBruteHP { get; set; } = 90;
        public static int LowerBoundWitchHP { get; set; } = 30;
        public static int UpperBoundWitchHP { get; set; } = 70;

        public static int LowerBoundGoblinDamage { get; set; } = 1;
        public static int UpperBoundGoblinDamage { get; set; } = 10;
        public static int LowerBoundBruteDamage { get; set; } = 50;
        public static int UpperBoundBruteDamage { get; set; } = 80;
        public static int LowerBoundWitchDamage { get; set; } = 60;
        public static int UpperBoundWitchDamage { get; set; } = 90;

        public static int ExperienceFromDefeatedGoblin { get; set; } = 10;
        public static int ExperienceFromDefeatedBrute { get; set; } = 30;
        public static int ExperienceFromDefeatedWitch { get; set; } = 70;


    }
}
