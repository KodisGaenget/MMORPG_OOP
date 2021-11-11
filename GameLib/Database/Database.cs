using System;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GameLib
{
    public class Database
    {
        string connectionString = "Server=40.85.84.155;Database=OOP_VIT;User=Student13;Password=big-bada-boom!;";

        public IEnumerable<Player> GetPlayers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Player>("SELECT Id, FirstName FROM F8");
            }
        }

    }
}
