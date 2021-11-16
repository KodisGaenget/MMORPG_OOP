using Characters;
using GameInterfaces;

namespace GameLib
{
    internal class PlayerLoader : ILoadable
    {
        private Database db;
        private Player p;
        private int id;


        public PlayerLoader(Database db, int id)
        {
            this.id = id;
            this.db = db;
            Load();
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

        public Player GetCharacter()
        {
            return p;
        }
    }
}

