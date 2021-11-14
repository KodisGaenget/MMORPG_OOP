using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLib
{
    public class Inventory
    {
        public int Id { get; private set; }
        Dictionary<int, int> items = new();

        public Inventory()
        {

        }
        internal IReadOnlyDictionary<int, int> GetInventory()
        {
            var readOnly = (IReadOnlyDictionary<int, int>)items.ToDictionary(pair => pair.Key, pair => pair.Value);
            return readOnly;
        }

        internal void AddItem(int newItem, int amount)
        {
            items.Add(newItem, amount);
        }

        public void ImportInventory(Dictionary<int, int> newItems)
        {
            foreach (var item in newItems)
            {
                items.TryAdd(item.Key, item.Value);
            }
        }

        internal void RemoveFromItem(int item)
        {
            items.Remove(item);
        }

    }

}