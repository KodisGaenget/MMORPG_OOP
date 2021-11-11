using System;

namespace GameLib
{
    public class Consumable : Item
    {
        public int AmountToRestore { get; set; }
        public ConsumableType ConsumableType { get; set; }
        public Consumable(string name, int id, int price, int amountToRestore, ConsumableType consumableType)
        {
            Name = name;
            Id = id;
            AmountToRestore = amountToRestore;
            ConsumableType = consumableType;
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