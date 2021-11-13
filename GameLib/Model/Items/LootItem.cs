using System;

namespace GameLib
{
    public class LootItem : Item // BEHÖVS DENNA VERKLIGEN?
    {

        public LootItem(string name, int dropChance)
        {
            Name = name;
            DropChance = dropChance;
        }
    }
}