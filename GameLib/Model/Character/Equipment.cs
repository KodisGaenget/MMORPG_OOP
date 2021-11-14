using System.Collections.Generic;
using System.Linq;

namespace GameLib
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
        private Database db;
        // private Armor newArmor;
        // private Weapon newWeapon;

        public Equipment(Database db)
        {
            this.db = db;
        }

        internal void ImportEquipment(Dictionary<string, int> eqList)
        {
            foreach (var item in eqList)
            {
                CurrentEquipped[item.Key] = item.Value;
            }
        }

        public override string ToString()
        {
            Checker checker = new();
            string equippedString = "is equipped with:\n";
            foreach (var item in CurrentEquipped)
            {
                if (item.Value == 0)
                {
                    equippedString += $"{item.Key}: Unequipped\n";
                    continue;
                }
                if (checker.GetItemType(item.Key) == "Armor")
                {
                    Armor armor = db.GetArmorItem(item.Value);
                    equippedString += $"{item.Key}: {armor.Name} - Defense {armor.Defense}\n";
                    continue;
                }
                if (checker.GetItemType(item.Key) == "Weapon")
                {
                    // System.Console.WriteLine(item.Value);
                    var weapon = db.GetWeaponItem(item.Value);
                    equippedString += $"{item.Key}: {weapon.Name} {weapon.MinDamage}-{weapon.MaxDamage} Damage\n";
                    continue;
                }
            }
            return equippedString;
        }
    }
}