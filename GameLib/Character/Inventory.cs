using System;
using System.Collections.Generic;

namespace GameLib
{
    class Inventory
    {
        List<Item> items = new();


        public void AddItemToInventory(Item item)
        {
            items.Add(item);
        }

        internal void RemoveFromItem(Item item)
        {
            items.Remove(item);
        }
    }

}