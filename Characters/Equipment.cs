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

        public IReadOnlyDictionary<string, int> GetEquipment()
        {
            var readOnly = (IReadOnlyDictionary<string, int>)CurrentEquipped.ToDictionary(pair => pair.Key, pair => pair.Value);
            return readOnly;
        }

        internal void EquipItem(string slot, int newItem)
        {
            CurrentEquipped[slot] = newItem;
        }

        internal void UnequipItem(string slot, int item)
        {
            CurrentEquipped[slot] = item;
        }
    }
}