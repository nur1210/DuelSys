using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    internal static class Connection
    {
        private static readonly string _conn = "Server=localhost;Uid=root;Database=duelsys_db; port=3307; Pwd=";

        public static MySqlConnection OpenConnection()
        {
            var conn = new MySqlConnection(_conn);
            conn.Open();
            return conn;
        }
    }
}
