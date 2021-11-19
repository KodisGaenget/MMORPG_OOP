using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System;
using Items;
using Characters;

namespace DataManager
{
    public class Database
    {
        string connectionString = "Server=40.85.84.155;Database=OOP_VIT;User=Student13;Password=big-bada-boom!;";


        #region Save functions

        public int NewPlayer(Player p)
        {
            int newId;
            string sql = "EXEC Add_NewPlayer @name, @ohp, @chp, @power, @armor, @dmg, @lvl, @cexp, @pos, @class";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                newId = connection.Query(sql, new { @name = p.Name, @ohp = p.OriginalHealth, @chp = p.CurrentHealth, @power = p.Power, @armor = p.Armor, @dmg = p.BaseDamage, @lvl = p.Level, @cexp = p.CurrentExp, @pos = p.Position, @class = p.Class }).First();
            }
            return newId;
        }

        public void UpdatePlayer(Player p)
        {
            string sql = "EXEC UpdatePlayer = @playerID, @ohp, @chp, @power, @armor, @dmg, @lvl, @cexp, @pos, @class";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, new { @playerID = p.Id, @ohp = p.OriginalHealth, @chp = p.CurrentHealth, @power = p.Power, @armor = p.Armor, @dmg = p.BaseDamage, @lvl = p.Level, @cexp = p.CurrentExp, @pos = p.Position, @class = p.Class });
            }
        }

        internal void SaveInventory(Player p)
        {
            if (p.inDb)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "Delete Inventory where PlayerId = @playerID";
                    connection.Execute(sql, new { @playerID = p.Id });
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var inventory = p.Inventory.GetInventory();
                foreach (var item in inventory)
                {
                    if (item.Value > 0)
                    {
                        string sql = "Insert into Inventory (PlayerId, ItemId, Amount) values (@playerID, @item, @amount) ";
                        connection.Execute(sql, new { @playerID = p.Id, @item = item.Key, @amount = item.Value });
                    }
                }
            }
        }
        #endregion 

        #region Load functions

        public Player LoadPlayer(int Id)
        {
            string sql = "SELECT Id, Name, OriginalHealth, CurrentHealth, Power, Armor, BaseDamage, Level, CurrentExp, Position, Class, CoinPurse FROM Character WHERE Id = @playerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Player>(sql, new { @playerID = Id }).First();
            }
        }

        internal Enemy LoadEnemy(int id)
        {
            string sql = "SELECT Id, Name, OriginalHealth, CurrentHealth, Power, Armor, BaseDamage, Level, CoinPurse, ExpValue FROM Character WHERE Id = @charId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Enemy>(sql, new { @charId = id }).First();
            }
        }

        public Dictionary<int, int> LoadInventory(int id)
        {
            string sql = "SELECT ItemId, Amount FROM Character as p inner join Inventory as inv on inv.PlayerID = p.Id  WHERE p.Id = @charId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query(sql, new { @charId = id }).ToDictionary(p => (int)p.ItemId, p => (int)p.Amount);
            }
        }

        public Dictionary<string, int> LoadEquipment(int charId)
        {
            string sql = "EXEC LoadEquipped @charId;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query(sql, new { @charId = charId }).ToDictionary(p => (string)p.Slot, p => (int)p.Id);
            }
        }
        #endregion

        #region Recive functions

        internal Dictionary<int, string> GetAllItems()
        {
            string sql = "Exec GetAllItems";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query(sql).ToDictionary(p => (int)p.Id, p => (string)p.ItemType);
            }
        }

        internal Armor GetArmorItem(int id)
        {
            string sql = "Exec GetArmorItem @itemID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Armor>(sql, new { @itemID = id }).First();
            }
        }

        internal Weapon GetWeaponItem(int id)
        {
            string sql = "Exec GetWeaponItem @itemID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Weapon>(sql, new { @itemID = id }).First();
            }
        }

        internal Consumable GetConsumableItem(int id)
        {
            string sql = "Exec GetConsumableItem @itemID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Consumable>(sql, new { @itemID = id }).First();
            }
        }

        internal Key GetKeyItem(int id)
        {
            string sql = "Exec GetKeyItem @itemID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Key>(sql, new { @itemID = id }).First();
            }
        }


        #endregion

        #region CreateFunctions

        public void Add_NewItem(string newName, Nullable<int> newPrice, string newItemType, string newSlot, Nullable<int> newMinDmg, Nullable<int> newMaxDmg, string newWeaponType, Nullable<int> newDef, string newMaterial, Nullable<int> newAmToRest, string newConsType, Nullable<int> newMaxStack)
        {
            string sql = "EXEC Add_NewItem @name, @price, @itemType, @slot, @mindmg, @maxdmg, @weapontype, @def, @type, @amtorest, @constype, @maxstack";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, new { @name = newName, @price = newPrice, @Itemtype = newItemType, @slot = newSlot, @mindmg = newMinDmg, @maxdmg = newMaxDmg, @weaponType = newWeaponType, @def = newDef, @type = newMaterial, @amtorest = newAmToRest, @constype = newConsType, @maxstack = newMaxStack });
            }
        }

        #endregion
    }
}
