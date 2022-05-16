using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    internal static class Connection
    {
        private static readonly string _conn = ConnConfig.Default.ConnStr;

        public static MySqlConnection OpenConnection()
        {
            var conn = new MySqlConnection(_conn);
            conn.Open();
            return conn;
        }
    }
}
