using System;

namespace GameLib
{
    public abstract class Item
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
        public String ItemType { get; init; }
        public int DropChance { get; set; }
        public Slot Slot { get; set; }
    }
}