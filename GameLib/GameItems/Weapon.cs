using System;

namespace GameLib
{
    public class Weapon : Item
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Weapon(string name, int id, int price, int minDamage, int maxDamage)
        {
            Name = name;
            Id = id;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}
