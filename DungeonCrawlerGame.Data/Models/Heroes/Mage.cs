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
                return true;
            }
        }
        public void RenewHPForMana()
        {
            if (Mana >= StartValues.ManaConsumptionForRenewingHP)
            {
                HealthPoints = MaxHealthPoints;
                Mana -= StartValues.ManaConsumptionForRenewingHP;
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
            }
        }
    }
}
