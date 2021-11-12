using System;

namespace GameLib
{
    public class Armor : Item
    {
        public int Value { get; set; }
        public ArmorSlot Slot { get; set; }
        public ArmorType Type { get; set; }
        public Armor(string name, int id, int price, int value, ArmorSlot slot, ArmorType type)
        {
            Name = name;
            Id = id;
            Price = price;
            Value = value;
            Slot = slot;
            Type = type;
            ItemType = this.GetType().ToString();

        }
    }

    public enum ArmorSlot
    {
        Helmet,
        Chest,
        Gloves,
        Legs,
        Boots
    }

    public enum ArmorType
    {
        Cloth,
        Leather,
        Plate
    }
}