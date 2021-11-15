using System;

namespace GameLib
{
    public class Armor : Item
    {
        public int Defense { get; set; }

        public ArmorType Type { get; set; }

        public Armor(string name, int id, int price, int defense, Slot slot, ArmorType type, String itemType)
        {
            Name = name;
            Id = id;
            Price = price;
            Defense = defense;
            Slot = slot;
            Type = type;
            ItemType = itemType;
        }

        // public Armor()
        // {

        // }
    }

    public enum ArmorType
    {
        Cloth,
        Leather,
        Plate
    }
}