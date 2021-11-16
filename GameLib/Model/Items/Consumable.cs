using System;

namespace GameLib
{
    public class Consumable : Item
    {
        public int AmountToRestore { get; set; }
        public ConsumableType ConsumableType { get; set; }
        public int MaxStack { get; set; }

        public Consumable(string name, int id, int price, int amountToRestore, ConsumableType consumableType, ItemType itemType)
        {
            Name = name;
            Id = id;
            Price = price;
            AmountToRestore = amountToRestore;
            ConsumableType = consumableType;
            ItemType = itemType;
        }

        public Consumable()
        {
            //Needed to load from database.
        }
    }
    public enum ConsumableType
    {
        HealthPotion,
        PowerPotion,
        ArmorPotion,
        DamagePotion,
        CritPotion
    }
}