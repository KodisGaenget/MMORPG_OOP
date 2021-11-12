using System.Collections.Generic;
using System.Linq;

namespace GameLib
{
    public class Equipment
    {
        public Armor Helmet { get; private set; }
        public Armor Chest { get; private set; }
        public Armor Gloves { get; private set; }
        public Armor Legs { get; private set; }
        public Armor Boots { get; private set; }
        public Weapon Weapon { get; private set; }
        private Armor newArmor;
        private Weapon newWeapon;

        public Equipment()
        {

        }

        internal Item SetSlot(Item item)
        {
            GetItemType(item);
            if (newWeapon != null)
            {
                if (Weapon != null)
                {
                    var oldWeapon = Weapon;
                    Weapon = newWeapon;
                    newWeapon = null;
                    return oldWeapon;
                }
                Weapon = newWeapon;
            }
            if (newArmor != null)
            {
                // newArmor.Slot;
            }

            return null;
        }

        private void GetItemType(Item item)
        {
            if (item is Weapon)
            {
                newWeapon = item as Weapon;
            }
            else if (item is Armor)
            {
                newArmor = item as Armor;
            }

        }


        //FIXME Felsök och kan inte sortera in items i eq.
        internal void SortEq(List<Item> eqList)
        {
            foreach (var item in eqList)
            {
                //== "Helmet" || item.ItemType == "Chest" || item.ItemType == "Gloves" || item.ItemType == "Legs" || item.ItemType == "Boots"
                if (item.ItemType == "Armor")
                {
                    Armor armItem = item as Armor;
                    foreach (var var in this.GetType().GetProperties())
                    {
                        // System.Console.WriteLine(armItem.Id);
                        // if (var.Name == armItem.ArmorSlot.ToString())
                        // {
                        //     System.Console.WriteLine("HITTAD!");
                        // }
                    }
                }
                else
                {
                    Weapon = item as Weapon;
                }
            }
        }

        public override string ToString()
        {
            return $"Helmet: {Helmet.Name}\n Chest: {Chest.Name}\n Gloves: {Gloves.Name}\n Legs: {Legs.Name}\n Boots: {Boots.Name}\n Weapon: {Weapon.Name}";
        }

    }
}