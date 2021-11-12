﻿using System;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GameLib
{
    public class Database
    {
        string connectionString = "Server=40.85.84.155;Database=OOP_VIT;User=Student13;Password=big-bada-boom!;";


        public IEnumerable<Player> LoadPlayer(int Id)
        {
            string sql = "SELECT Id, Name, OriginalHealth, CurrentHealth, Power, Armor, Damage, Level, CurrentExp, Position, Class FROM Player WHERE Id = @playerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Player>(sql, new { @playerID = Id });
            }
        }

        public void SavePlayer(Player p)
        {
            string sql = "UPDATE Player Set OriginalHealth = @ohp, CurrentHealth = @chp, Power = @power, Armor = @armor, Damage = @dmg, Level = @lvl, CurrentExp = @cexp, Position = @pos, Class = @class WHERE Id = @playerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, new { @playerID = p.Id, @ohp = p.OriginalHealth, @chp = p.CurrentHealth, @power = p.Power, @armor = p.Armor, @dmg = p.Damage, @lvl = p.Level, @cexp = p.CurrentExp, @pos = p.Position, @class = p.Class });
            }
        }

        internal void SaveInventory(Player p, List<Item> items)
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
                foreach (var item in items)
                {
                    string sql = "Insert into Inventory (PlayerId, ItemId) values (@playerID, @item) ";
                    connection.Execute(sql, new { @playerID = p.Id, @item = item });
                }
            }
        }

        public IEnumerable<Item> LoadInventory(int Id)
        {
            string sql = "SELECT inv.ItemId FROM Player as p inner join Inventory as inv on inv.PlayerID = p.Id  WHERE p.Id = @playerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Item>(sql, new { @playerID = Id });
            }
        }

        //FIXME BYGG OM EQUIPMENT!!
        public IEnumerable<Equipment> LoadEquipment(int playerId)
        {
            string sql = "Select * From Equipped eq inner join Item i on eq.Helmet = i.ItemId or Chest = i.ItemId or gloves = ItemId or Legs = ItemId or Boots = ItemId or Weapon = ItemId where eq.PlayerId = @playerID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Equipment>(sql, new { @playerID = playerId });
            }
        }
    }
}
