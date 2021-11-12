using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLib
{
    public class CharacterLoader : ILoadable
    {
        private Database db;
        private Player p;
        private Inventory inv = new();


        public CharacterLoader(Database db)
        {
            this.db = db;
            Load();
        }

        public bool Load()
        {
            p = db.LoadPlayer().First();
            inv.ImportInventory(db.LoadInventory(p.Id).ToList());
            p.SetInventory(inv);
            return true;
        }

        private void SaveCharacter(Inventory inv)
        {
            db.SavePlayer(p);
            inv.SaveInventory(p, db);
        }

        public Player GetCharacter()
        {
            return p;
        }

        // public void Save(Database db, Player p, Inventory inv)
        // {
        //     SaveCharacter(inv);
        // }
    }
}

