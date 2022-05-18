using MySql.Data.MySqlClient;

namespace DAL
{
    internal static class Connection
    {
        private static readonly string Conn = ConnConfig.Default.ConnStr;

        public static MySqlConnection OpenConnection()
        {
            var conn = new MySqlConnection(Conn);
            conn.Open();
            return conn;
        }
    }
}
