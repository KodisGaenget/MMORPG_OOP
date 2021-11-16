using System;

namespace GameLib
{
    public class Armor : Item
    {
        public int Defense { get; set; }

        public ArmorType Material { get; set; }

        public Armor(string name, int id, int price, int defense, Slot slot, ArmorType material, ItemType itemType)
        {
            Name = name;
            Id = id;
            Price = price;
            Defense = defense;
            Slot = slot;
            Material = material;
            ItemType = itemType;
        }

        public Armor()
        {
            //Needed to load from database.
        }
    }

    public enum ArmorType
    {
        Cloth,
        Leather,
        Plate
    }
}