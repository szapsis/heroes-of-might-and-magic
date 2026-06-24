using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_of_Might_and_Magic.Models
{
    public class Unit
    {
        public string Name { get; private set; }
        public int Count { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }

        public int Health { get; private set; }

        public int TotalHealth { get; private set; }

        public Unit(string name, int count, int attack, int defense, int minDamage, int maxDamage, int health)
        {
            Name = name;
            Count = count;
            Attack = attack;
            Defense = defense;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Health = health;
            TotalHealth = Health * Count;
        }

        public void TakeDamage(int damage)
        {
            TotalHealth -= damage;

            if (TotalHealth < 0)
            {
                TotalHealth = 0;
            }
        }

        public bool IsAlive
        {
            get { return TotalHealth > 0; }
        }

        private static Random random = new Random();

        public int GetDamage()
        {
            return random.Next(MinDamage, MaxDamage + 1);
        }
    }
}
