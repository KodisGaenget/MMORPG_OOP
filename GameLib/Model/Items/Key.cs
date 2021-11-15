using System;

namespace GameLib
{
    public class Key        // Miscellaneous
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public Key(int id, string name, String itemType)
        {
            Id = id;
            Name = name;
            ItemType = itemType;
        }
    }
}