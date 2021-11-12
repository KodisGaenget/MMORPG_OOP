using System;

namespace GameLib
{
    public class Weapon : Item
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public WeaponType Type { get; set; }

        public Weapon(string name, int id, int price, int minDamage, int maxDamage, WeaponType type)
        {
            Name = name;
            Id = id;
            Price = price;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Type = type;
        }
    }

    public enum WeaponType
    {
        Daggers,
        ThrowingStar,
        DoubleEdgedAxe,
        Warhammer,
        Staff,
        SpellBook
    }
}
