using System;
using System.Collections.Generic;
using System.Linq;

namespace Characters
{
    public class Inventory
    {
        public int Id { get; private set; }
        Dictionary<int, int> items = new();

        public Inventory()
        {
        }

        public IReadOnlyDictionary<int, int> GetInventory()
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

        public void AddItem(int newItem, int amount)
        {
            if (IsItemIDInInventory(newItem))
            {
                if (FindItem(newItem).Value + amount <= 5)
                {
                    items[newItem] += amount;

                }
            }
            else
            {
                items.Add(newItem, amount);
            }
        }

        public void RemoveItem(int item, int amount = 1)
        {
            var itemToRemove = FindItem(item);

            if (itemToRemove.Value == 1)
            {
                items.Remove(itemToRemove.Key);
            }
            else
            {
                items[itemToRemove.Key] = -amount;
            }
        }

        public bool IsItemIDInInventory(int itemID)
        {
            foreach (var item in items)
            {
                if (item.Key == itemID)
                {
                    return true;
                }
            }
            return false;
        }

        private KeyValuePair<int, int> FindItem(int searched)
        {
            KeyValuePair<int, int> founded = new();

            foreach (KeyValuePair<int, int> item in items)
            {
                if (item.Key == searched)
                {
                    founded = item;
                }
            }
            return founded;
        }

    }

}