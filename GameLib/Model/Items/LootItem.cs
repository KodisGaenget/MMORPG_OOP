using System;

namespace GameLib
{
    public class LootItem : Item // BEHÖVS DENNA VERKLIGEN?
    {
        public int DropChance { get; set; }
        public LootItem(string name, int dropChance)
        {
            Name = name;
            DropChance = dropChance;
        }
    }
}