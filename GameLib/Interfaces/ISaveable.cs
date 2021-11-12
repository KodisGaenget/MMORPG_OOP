using System;

namespace GameLib
{
    public interface ISaveable
    {
        void Save(Database db, Player p, Inventory inv);
    }
}