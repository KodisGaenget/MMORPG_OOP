using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLib
{
    public class CharacterLoader : ILoadable
    {
        public Database db { get; private set; }
        public Player p { get; private set; }
        public Inventory inv = new();

        public CharacterLoader(Database db)
        {
            this.db = db;
            Load();
        }

        public void Load()
        {
            p = db.LoadPlayer().First();
            inv.ImportInventory(db.LoadInventory(p.Id).ToList());
            p.SetInventory(inv);
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

