using System;

namespace GameLib
{
    public abstract class Item
    {
        public string Name { get; init; }
        public int Id { get; init; }
        public int Price { get; init; }
    }
}