using System;

namespace GameLib
{
    public class Armor : Item
    {
        public int Defense { get; set; }

        public ArmorType Type { get; set; }

        public Armor(string name, int id, int price, int value, Slot slot, ArmorType type)
        {
            Name = name;
            Id = id;
            Price = price;
            Defense = value;
            Slot = slot;
            Type = type;
            ItemType = this.GetType().ToString();
        }

        public Armor()
        {

        }
    }

    public enum Slot
    {
        Helmet,
        Chest,
        Gloves,
        Legs,
        Boots,
        Weapon
    }

    public enum ArmorType
    {
        Cloth,
        Leather,
        Plate
    }
}