using Logic.Exceptions;
using MySql.Data.MySqlClient;

namespace DAL
{
    internal static class Connection
    {
        private static string Conn = ConnConfig.Default.ConnDev;

        public static MySqlConnection OpenConnection()
        {
            try
            {
                var conn = new MySqlConnection(Conn);
                conn.Open();
                return conn;
            }
            catch (MySqlException)
            {
                try
                {
                    Conn = ConnConfig.Default.ConnProd;
                    var conn = new MySqlConnection(Conn);
                    conn.Open();
                    return conn;
                }
                catch (MySqlException)
                {
                    throw new InternalErrorException();
                }
            }
        }
    }
}
