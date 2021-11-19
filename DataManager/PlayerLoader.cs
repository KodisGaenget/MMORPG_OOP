using Characters;

namespace DataManager
{
    public class PlayerLoader
    {
        private Database db;
        private Player p;
        private int id;


        public PlayerLoader(Database db)
        {
            this.db = db;
        }

        public Player GetPlayer(int id)
        {
            this.id = id;
            Load();
            return p;

        }

        public bool Load()
        {
            Inventory inv = new();
            Equipment eq = new();
            p = db.LoadPlayer(id);
            inv.ImportInventory(db.LoadInventory(p.Id));
            eq.ImportEquipment(db.LoadEquipment(p.Id));
            p.Load(inv, eq, new());
            return true;
        }
    }
}

