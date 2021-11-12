using System;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GameLib
{
    public class Database
    {
        string connectionString = "Server=40.85.84.155;Database=OOP_VIT;User=Student13;Password=big-bada-boom!;";


        public IEnumerable<Player> LoadPlayer()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Player>("SELECT Id, Name, OriginalHealth, CurrentHealth, Power, Armor, Damage, Level, CurrentExp FROM Player");
            }
        }

        public void SavePlayer(Player p)
        {
            string sql = "UPDATE Player Set OriginalHealth = @ohp, CurrentHealth = @chp, Power = @power, Armor = @armor, Damage = @dmg, Level = @lvl, CurrentExp = @cexp, Position = @pos, Class = @class WHERE Id = @playerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, new { @playerID = p.Id, @ohp = p.OriginalHealth, @chp = p.CurrentHealth, @power = p.Power, @armor = p.Armor, @dmg = p.Damage, @lvl = p.Level, @cexp = p.CurrentExp, @pos = p.Position, @class = p.CharClass });
            }
        }

        internal void SaveInventory(Player p, List<Item> items)
        {
            if (p.inDb)
            {
                string sql = "UPDATE Inventory Set OriginalHealth = @ohp, CurrentHealth = @chp, Power = @power, Armor = @armor, Damage = @dmg, Level = @lvl, CurrentExp = @cexp, Position = @pos WHERE Id = @playerID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Execute(sql, new { @playerID = p.Id, @ohp = p.OriginalHealth, @chp = p.CurrentHealth, @power = p.Power, @armor = p.Armor, @dmg = p.Damage, @lvl = p.Level, @cexp = p.CurrentExp, @pos = p.Position });
                }
            }
        }

        public IEnumerable<Item> LoadInventory(int playerId)
        {
            string sql = "SELECT Id FROM Player as p inner join Inventory as inv on PlayerID = PlayerID  WHERE PlayerID = @playerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Item>(sql, new { @playerID = playerId });
            }
        }
    }
}
