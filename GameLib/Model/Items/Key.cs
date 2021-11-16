using System;

namespace GameLib
{
    public class Key : Item      // Miscellaneous
    {
        public Key(int id, string name, ItemType itemType)
        {
            Id = id;
            Name = name;
            ItemType = itemType;
        }
    }
}