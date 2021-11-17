using Characters;
using System;

namespace DataManager
{
    public class PlayerSaver
    {
        private Database db;
        private Player p;

        public PlayerSaver(Database db, Player p)
        {
            this.db = db;
            this.p = p;
            Save();
        }

        public bool Save()
        {
            try
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
            catch (Exception)
            {
                return false;
            }
            return true;

        }
    }
}
