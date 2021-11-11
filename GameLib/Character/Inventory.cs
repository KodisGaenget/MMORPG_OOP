using System;
using System.Collections.Generic;

namespace GameLib
{
    class Inventory
    {
        public int Id { get; private set; }
        List<Item> items = new();


        public void AddItemToInventory(Item item)
        {
            items.Add(item);
        }

        internal void RemoveFromItem(Item item)
        {
            items.Remove(item);
        }

        public void SaveInventory(Database db)
        {
            db.SaveInventory(items);
        }
    }

}