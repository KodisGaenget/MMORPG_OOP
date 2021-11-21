using System;
using System.Collections.Generic;
using Items;


namespace DataManager
{
    public class ItemLoader
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
                System.Console.WriteLine("Database Error: ItemLoader-E0031", e);
                return false;
            }
            return true;
        }

        public (Weapon weapon, Armor armor, Consumable consumable, Key key) FindItem(int id)
        {
            foreach (var item in itemList)
            {
                if (item.Key == id)
                {
                    if (item.Value == "Armor")
                    {
                        return (null, GetArmorDetails(id), null, null);
                    }
                    else if (item.Value == "Weapon")
                    {
                        return (GetWeaponDetails(id), null, null, null);
                    }
                    else if (item.Value == "Consumable")
                    {
                        return (null, null, GetConsumableDetails(id), null);
                    }
                    else if (item.Value == "Key")
                    {
                        return (null, null, null, GetKeyDetails(id));
                    }
                }
            }
            return (new(), new(), new(), new());
        }

        private void LoadItems()
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
                    keyList.Add(db.GetKeyItem(item.Key));
                }
            }
        }

        public Weapon GetWeaponDetails(int id)
        {
            foreach (var item in weaponList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return new();
        }

        public Armor GetArmorDetails(int id)
        {
            foreach (var item in armorList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return new();
        }

        public Consumable GetConsumableDetails(int id)
        {
            foreach (var item in consumableList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return new();
        }

        public Key GetKeyDetails(int id)
        {
            foreach (var item in keyList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return new();
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

