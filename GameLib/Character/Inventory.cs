using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Inventory
    {
        public int Id { get; private set; }
        List<Item> items = new();


        internal void AddItemToInventory(Item item)
        {
            items.Add(item);
        }

        public void ImportInventory(List<Item> items)
        {
            this.items.AddRange(items);
        }

        internal void RemoveFromItem(Item item)
        {
            items.Remove(item);
        }

        public void SaveInventory(Player p, Database db)
        {
            db.SaveInventory(p, items);
        }
    }

}