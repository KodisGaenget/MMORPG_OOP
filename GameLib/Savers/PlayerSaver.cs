using System;

namespace GameLib
{
    public class PlayerSaver : ISaveable
    {
        private Database db;
        private Player p;

        public PlayerSaver(Database db, Player p)
        {
            this.db = db;
            this.p = p;
            Save();
        }

        public void Save()
        {
            if (p.inDb)
            {
                db.UpdatePlayer(p);
            }
            else
            {
                db.NewPlayer(p);
            }
            db.SaveInventory(p);
        }
    }
}
