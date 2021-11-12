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
        private Equipment eq;


        public CharacterLoader(Database db)
        {
            this.db = db;
            Load();
        }

        public bool Load()
        {
            p = db.LoadPlayer(1).First();
            inv.ImportInventory(db.LoadInventory(p.Id).ToList());
            // eq.SortEq(db.LoadEquipment(p.Id).ToList());
            p.SetInventory(inv);
            // p.SetEquipment(eq);

            return true;
        }

        public Player GetCharacter()
        {
            return p;
        }



        // private void SaveCharacter(Inventory inv)
        // {
        //     db.SavePlayer(p);
        //     inv.SaveInventory(p, db);
        // }
        // public void Save(Database db, Player p, Inventory inv)
        // {
        //     SaveCharacter(inv);
        // }
    }
}

