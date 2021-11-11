using System;

namespace GameLib
{
    public class Armor : Item
    {
        public int ArmorValue { get; set; }
        public ArmorType ArmorType { get; set; }

        public Armor(string name, int id, int price, int armorValue, ArmorType _ArmorType)
        {
            string Name = name;
            int Id = id;
            Price = price;
            int ArmorValue = armorValue;
            ArmorType = _ArmorType;
        }
    }

    public enum ArmorType
    {
        Helmet,
        Chest,
        Gloves,
        Legs,
        Boots
    }
}