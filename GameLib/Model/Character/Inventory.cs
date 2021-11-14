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

        public void ImportInventory(Dictionary<int, int> newItems)
        {
            foreach (var item in newItems)
            {
                items.TryAdd(item.Key, item.Value);
            }
        }

        internal void AddItem(int newItem, int amount)
        {
            items.Add(newItem, amount);
        }

        internal void RemoveItem(int item, int amount = 1)
        {
            var itemToRemove = CheckAndFind.FindItem(item, GetInventory());

            if (itemToRemove.Value == 1)
            {
                items.Remove(itemToRemove.Key);
            }
            else
            {
                items[itemToRemove.Key] = -amount;
            }
        }



    }

}