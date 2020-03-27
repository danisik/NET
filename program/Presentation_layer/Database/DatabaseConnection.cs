using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Data_layer.Data
{
    class DatabaseConnection
    {
        public static readonly String databaseConnectionString =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=Database.mdf;Integrated Security=True";

        private SqlConnection connection;

        public DatabaseConnection()
        {
            connection = new SqlConnection(databaseConnectionString);
        }

        private SqlConnection Connection { get; }
    }
}
