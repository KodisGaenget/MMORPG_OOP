using System;

namespace GameLib
{
    public class Item
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
        public String ItemType { get; init; }
        public WeaponType WeaponType { get; set; }
        public ArmorSlot ArmorSlot { get; set; }
        public ArmorType ArmorType { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int ArmorValue { get; set; }
        public int AmountToRestore { get; set; }
        public ConsumableType ConsumableType { get; set; }
        public int DropChance { get; set; }



    }
}