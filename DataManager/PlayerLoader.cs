using Characters;
using GameInterfaces;

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

        public Player LoadChoosenPlayer(int id)
        {
            this.id = id;
            Load();
            return GetCharacter();

        }

        public bool Load()
        {
            Inventory inv = new();
            Equipment eq = new();
            p = db.LoadPlayer(id);
            inv.ImportInventory(db.LoadInventory(p.Id));
            eq.ImportEquipment(db.LoadEquipment(p.Id));
            p.SetInventory(inv);
            p.SetEquipment(eq);

            return true;
        }

        private Player GetCharacter()
        {
            return p;
        }
    }
}

