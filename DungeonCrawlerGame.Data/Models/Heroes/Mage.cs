using DungeonCrawlerGame.Data.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerGame.Data.Models.Heroes
{
    public class Mage : Hero
    {
        public Mage()
        {
            MaxHealthPoints = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundMageHP, StartValues.UpperBoundMageHP);
            Damage = RandomNumberGenerator.GenerateInRange(StartValues.LowerBoundMageDamage, StartValues.UpperBoundMageDamage);
            HealthPoints = MaxHealthPoints;
            Mana = ManaAmount();
        }
        public int Mana { get; set; }
        public int ManaAmount()
        {
            return Mana = CurrentLevel * 10;
        }
        public void ManaRefill()
        {
            ManaAmount();
        }

        private bool _isRespawned = false;
        public bool Respawn()
        {
            if (_isRespawned)
                return false;
            else
            {
                _isRespawned = true;
                HealthPoints = MaxHealthPoints;
                return true;
            }
        }
        public override void BeAttacked(int damage)
        {
            HealthPoints -= damage;
            if (HealthPoints <= 0)
            {
                HealthPoints = 0;
                IsDead = true;
                if(Respawn())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Respawn!");
                    IsDead = false;
                }
            }
        }
        public bool CanRenewHPForMana()
        {
            return (Mana >= StartValues.ManaConsumptionForRenewingHP);
        }
        public void RenewHPForMana()
        {
            if (CanRenewHPForMana())
            {
                HealthPoints = MaxHealthPoints;
                Mana -= StartValues.ManaConsumptionForRenewingHP;
                Console.WriteLine("HP is renewed!");
            }
        }
        public override void Attack(Being monster)
        {
            if (Mana < StartValues.ManaConsumptionForAttacking)
                ManaRefill();
            else
            {
                monster.BeAttacked(Damage);
                Mana -= StartValues.ManaConsumptionForAttacking;
                ValuesWhenMonsterIsDefeated(monster as Monster);
            }
        }
        public override string ToString()
        {
            return $"I am mage!\n" +
                $"{base.ToString()}" +
                $"Mana:{Mana}\n";
        }
    }
}
