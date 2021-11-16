using System;
using System.Collections.Generic;
using GameInterfaces;

namespace GameLib
{
    public class ItemLoader : ILoadable
    {
        public Dictionary<int, string> itemList;
        public List<Armor> armorList = new();
        public List<Weapon> weaponList = new();
        public List<Consumable> consumableList = new();
        public List<Key> keyList = new();
        Database db;

        public ItemLoader(Database db)
        {
            this.db = db;
            itemList = db.GetAllItems();
            Load();
        }

        public bool Load()
        {
            try
            {
                LoadItems();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Database Error: ItemLoader-E0024", e);
                return false;
            }
            return true;
        }

        void LoadItems()
        {
            foreach (var item in itemList)
            {
                if (item.Value == "Armor")
                {
                    armorList.Add(db.GetArmorItem(item.Key));
                }
                else if (item.Value == "Weapon")
                {
                    weaponList.Add(db.GetWeaponItem(item.Key));
                }
                else if (item.Value == "Consumable")
                {
                    consumableList.Add(db.GetConsumableItem(item.Key));
                }
                else if (item.Value == "Key")
                {
                    //keyList.Add(db.GetKeyItem(item.Key));
                }
            }
        }
        public string GetItemType(int Id)
        {
            foreach (var item in itemList)
            {
                if (item.Key == Id)
                {
                    return item.Value;
                }
            }
            return "";
        }
    }
}

