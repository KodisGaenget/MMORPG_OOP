using System;
using System.Collections.Generic;
using Items;


namespace DataManager
{
    public class ItemLoader
    {
        public Dictionary<int, string> itemIdList;
        public List<Item> itemList = new();

        Database db;

        public ItemLoader(Database db)
        {
            this.db = db;
            itemIdList = db.GetAllItems();
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
                System.Console.WriteLine("Database Error: ItemLoader-E0031", e);
                return false;
            }
            return true;
        }

        private void LoadItems()
        {
            foreach (var item in itemIdList)
            {
                if (item.Value == "Armor")
                {
                    itemList.Add(db.GetArmorItem(item.Key));
                }
                else if (item.Value == "Weapon")
                {
                    itemList.Add(db.GetWeaponItem(item.Key));
                }
                else if (item.Value == "Consumable")
                {
                    itemList.Add(db.GetConsumableItem(item.Key));
                }
                else if (item.Value == "Key")
                {
                    itemList.Add(db.GetKeyItem(item.Key));
                }
            }
        }

        public Weapon GetWeaponDetails(int id)
        {
            foreach (var item in itemList)
            {
                if (item.Id == id)
                {
                    return item as Weapon;
                }
            }
            return new();
        }

        public Armor GetArmorDetails(int id)
        {
            foreach (var item in itemList)
            {
                if (item.Id == id)
                {
                    return item as Armor;
                }
            }
            return new();
        }

        public Consumable GetConsumableDetails(int id)
        {
            foreach (var item in itemList)
            {
                if (item.Id == id)
                {
                    return item as Consumable;
                }
            }
            return null;
        }

        public Key GetKeyDetails(int id)
        {
            foreach (var item in itemList)
            {
                if (item.Id == id)
                {
                    return item as Key;
                }
            }
            return null;
        }

        public Item GetItemDetails(int id)
        {
            foreach (var item in itemList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public string GetItemType(int Id)
        {
            foreach (var item in itemIdList)
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