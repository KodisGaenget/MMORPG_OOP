using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace GameLib
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
                newId = connection.Query(sql, new { @name = p.Name, @ohp = p.OriginalHealth, @chp = p.CurrentHealth, @power = p.Power, @armor = p.Armor, @dmg = p.Damage, @lvl = p.Level, @cexp = p.CurrentExp, @pos = p.Position, @class = p.Class }).First();
            }
            return newId;
        }

        public void UpdatePlayer(Player p)
        {
            string sql = "UPDATE Player Set OriginalHealth = @ohp, CurrentHealth = @chp, Power = @power, Armor = @armor, Damage = @dmg, Level = @lvl, CurrentExp = @cexp, Position = @pos, Class = @class WHERE Id = @playerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, new { @playerID = p.Id, @ohp = p.OriginalHealth, @chp = p.CurrentHealth, @power = p.Power, @armor = p.Armor, @dmg = p.Damage, @lvl = p.Level, @cexp = p.CurrentExp, @pos = p.Position, @class = p.Class });
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
            string sql = "SELECT Id, Name, OriginalHealth, CurrentHealth, Power, Armor, Damage, Level, CurrentExp, Position, Class FROM Player WHERE Id = @playerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Player>(sql, new { @playerID = Id }).First();
            }
        }

        public Dictionary<int, int> LoadInventory(int Id)
        {
            string sql = "SELECT ItemId, Amount FROM Player as p inner join Inventory as inv on inv.PlayerID = p.Id  WHERE p.Id = @playerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query(sql, new { @playerID = Id }).ToDictionary(p => (int)p.ItemId, p => (int)p.Amount);
            }
        }

        public Dictionary<string, int> LoadEquipment(int playerId)
        {
            string sql = "EXEC LoadEquipped @playerID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query(sql, new { @playerID = playerId }).ToDictionary(p => (string)p.Slot, p => (int)p.Id);
            }
        }
        #endregion

        #region Recive functions

        public Armor GetArmorItem(int id)
        {
            string sql = "Exec GetArmorItem @itemID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Armor>(sql, new { @itemID = id }).First();
            }
        }

        public Weapon GetWeaponItem(int id)
        {
            string sql = "Exec GetWeaponItem @itemID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Weapon>(sql, new { @itemID = id }).First();
            }
        }

        #endregion

    }
}
