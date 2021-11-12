using System;
using System.Collections.Generic;

namespace GameLib
{
    public class CharacterLoader : IDataManager
    {
        internal void Load(Database db, IEnumerable<Item> invList, Inventory inv)
        {
            LoadCharacter(invList, inv);
        }

        internal void Save(Database db, Player p, Inventory inv)
        {
            SaveCharacter(db, p, inv);
        }




        private void SaveCharacter(Database db, Player p, Inventory inv)
        {
            db.SavePlayer(p);
            inv.SaveInventory(p, db);
        }

        public Player LoadCharacter(Database db)
        {
            Player player = null;
            foreach (var character in db.LoadPlayer())
            {
                player = character;
                player.Load();
            }
            return player;
        }


        private void LoadCharacter(IEnumerable<Item> invList, Inventory inv)
        {
            inv.ImportInventory(ConvertToItemList(invList));
        }

        private List<Item> ConvertToItemList(IEnumerable<Item> inv)
        {
            List<Item> newList = new();
            foreach (var item in inv)
            {
                newList.Add(item);
            }
            return newList;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
