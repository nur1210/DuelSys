using Logic.Exceptions;
using MySql.Data.MySqlClient;

namespace DAL
{
    internal static class Connection
    {
        private static readonly string Conn = ConnConfig.Default.ConnStr;

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
                throw new InternalErrorException();
            }
        }
    }
}
