using System;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GameLib
{
    public class Database
    {
        string connectionString = "Server=40.85.84.155;Database=OOP_VIT;User=Student13;Password=big-bada-boom!;";


        public IEnumerable<Player> GetPlayer()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Player>("SELECT Id, Name, OriginalHealth, CurrentHealth, Power, Armor, Damage, Level, CurrentExp FROM Player");
            }
        }
        public IEnumerable<Item> GetInventory(int playerId)
        {
            string sql = "SELECT Id, Name, OriginalHealth, CurrentHealth, Power, Armor, Damage, Level, CurrentExp FROM Inventory WHERE PlayerID = @playerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Item>(sql, new { @playerID = playerId });
            }
        }
    }
}
