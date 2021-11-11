using System;

namespace GameLib
{
    public class LootItem : Item
    {
        public int DropChance { get; set; }
        public LootItem(string name, int dropChance)
        {
            Name = name;
            DropChance = dropChance;
        }
    }
}