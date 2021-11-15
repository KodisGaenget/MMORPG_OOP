using System.Collections.Generic;
using System.Linq;

namespace Characters
{
    public class Equipment
    {
        private Dictionary<string, int> CurrentEquipped = new()
        {
            { "Helmet", 0 },
            { "Chest", 0 },
            { "Gloves", 0 },
            { "Legs", 0 },
            { "Boots", 0 },
            { "Weapon", 0 }
        };

        public Equipment()
        {

        }

        public void ImportEquipment(Dictionary<string, int> eqList)
        {
            foreach (var item in eqList)
            {
                CurrentEquipped[item.Key] = item.Value;
            }
        }

        internal IReadOnlyDictionary<string, int> GetEquipment()
        {
            var readOnly = (IReadOnlyDictionary<string, int>)CurrentEquipped.ToDictionary(pair => pair.Key, pair => pair.Value);
            return readOnly;
        }

        internal void EquipItem(string slot, int newItem)
        {
            CurrentEquipped[slot] = newItem;
        }

        internal void RemoveItem(string slot, int item)
        {
            CurrentEquipped[slot] = item;
        }

        public override string ToString()
        {
            string equippedString = "";
            foreach (var item in CurrentEquipped)
            {
                if (item.Value == 0)
                {
                    equippedString += $"{item.Key}: Unequipped\n";
                }
                else if (CheckAndFind.GetItemType(item.Key) == "Armor" || CheckAndFind.GetItemType(item.Key) == "Weapon")
                {
                    equippedString += $"{item.Key}: Equipped\n";
                }
            }
            return equippedString;
        }
    }
}