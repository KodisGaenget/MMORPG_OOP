using Characters;
using System;

namespace DataManager
{
    public class Spawner
    {
        private Database db;
        private Enemy e;
        private int id;

        public Spawner(Database db)
        {
            this.db = db;
        }

        public Enemy GetEnemy(int id)
        {
            this.id = id;
            Load();
            return e;
        }

        public bool Load()
        {
            Inventory inv = new();
            Equipment eq = new();
            e = db.LoadEnemy(id);
            eq.ImportEquipment(db.LoadEquipment(e.Id));
            e.Load(eq);
            return true;
        }
    }
}
