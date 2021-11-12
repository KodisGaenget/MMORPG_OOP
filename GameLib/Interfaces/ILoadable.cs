using System;
using System.Collections.Generic;

namespace GameLib
{
    public interface ILoadable
    {
        void Load(Database db, IEnumerable<Item> invList, Inventory inv);
    }
}