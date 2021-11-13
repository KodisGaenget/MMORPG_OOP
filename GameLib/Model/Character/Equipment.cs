using System.Collections.Generic;
using System.Linq;

namespace GameLib
{
    public class Equipment
    {
        // public Armor Helmet { get; private set; }
        // public Armor Chest { get; private set; }
        // public Armor Gloves { get; private set; }
        // public Armor Legs { get; private set; }
        // public Armor Boots { get; private set; }
        // public Weapon Weapon { get; private set; }
        private Dictionary<string, int> CurrentEquipped = new()
        {
            { "Helmet", 0 },
            { "Chest", 0 },
            { "Gloves", 0 },
            { "Legs", 0 },
            { "Boots", 0 },
            { "Weapon", 0 }
        };
        private Database db;
        // private Armor newArmor;
        // private Weapon newWeapon;

        public Equipment(Database db)
        {
            this.db = db;
        }

        // internal Item SetSlot(Item item)
        // {
        //     // GetItemType(item);
        //     if (newWeapon != null)
        //     {
        //         // if (Weapon != null)
        //         // {
        //         //     var oldWeapon = Weapon;
        //         //     Weapon = newWeapon;
        //         //     newWeapon = null;
        //         //     return oldWeapon;
        //         // }
        //         // Weapon = newWeapon;
        //     }
        //     if (newArmor != null)
        //     {
        //         // newArmor.Slot;
        //     }

        //     return null;
        // }

        // private void GetItemType(Item item)
        // {
        //     if (item is Weapon)
        //     {
        //         newWeapon = item as Weapon;
        //     }
        //     else if (item is Armor)
        //     {
        //         newArmor = item as Armor;
        //     }

        // }

        internal void ImportEquipment(Dictionary<string, int> eqList)
        {
            foreach (var item in eqList)
            {
                CurrentEquipped[item.Key] = item.Value;
            }
        }

        internal string GetItemType(string type)
        {
            if (type == "Helmet" || type == "Chest" || type == "Gloves" || type == "Legs" || type == "Boots" || type == "Armor")
            {
                return "Armor";
            }
            else if (type == "Weapon")
            {
                return "Weapon";
            }

            return "Empty";

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
                else if (GetItemType(item.Key) == "Armor")
                {
                    // equippedString += $"{item.Key}: Equipped\n";
                    equippedString += $"{item.Key}: {db.GetArmorItem(item.Value).Name}";
                }
                else if (GetItemType(item.Key) == "Weapon")
                {
                    // equippedString += $"{item.Key}: Equipped\n";
                    equippedString += $"{item.Key}: {db.GetWeponItem(item.Value).Name}";
                }
            }
            return equippedString;
        }
    }
}