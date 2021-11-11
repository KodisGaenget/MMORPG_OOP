using System;

namespace GameLib
{
    public class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public int ArmorValue { get; set; }
        // int Chest { get; set; }
        // int Gloves { get; set; }
        // int Legs { get; set; }
        // int Boots { get; set; }
        public Armor(string name, int id, int armorValue, ArmorType _ArmorType)
        {
            string Name = name;
            int Id = id;
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