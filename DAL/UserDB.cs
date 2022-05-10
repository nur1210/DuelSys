using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserDB : IUserDB
    {
        public void AddUser(User user, string hashedPassword)
        {
            using var conn = Connection.OpenConnection();
            string sql = "INSERT INTO user (first_name, last_name, email, password, is_admin) VALUES (@FirstName, @LastName, @Email, @Password, @IsAdmin)";
            MySqlHelper.ExecuteNonQuery(conn, sql, new MySqlParameter("FirstName", user.FirstName), new MySqlParameter("LastName", user.LastName), new MySqlParameter("Email", user.Email), 
                new MySqlParameter("Password", hashedPassword), new MySqlParameter("IsAdmin", user.IsAdmin));
        }

        public void UpdateUser(User user)
        {
            using var conn = Connection.OpenConnection();
            string sql = "UPDATE user SET first_name = @FirstName, last_name = @LastName, email = @Email, password = @Password, is_admin = @IsAdmin WHERE id = @ID ";
            MySqlHelper.ExecuteNonQuery(conn, sql, new MySqlParameter("FirstName", user.FirstName), new MySqlParameter("LastName", user.LastName), new MySqlParameter("Email", user.Email), 
                new MySqlParameter("Password", user.Password), new MySqlParameter("IsAdmin", user.IsAdmin), new MySqlParameter("ID", user.Id));
        }

        public void DeleteUser(User user)
        {
            using var conn = Connection.OpenConnection();
            string sql = "DELETE FROM user WHERE id = @ID";
            MySqlHelper.ExecuteNonQuery(conn, sql, new MySqlParameter("ID", user.Id));
        }

        public List<User> GetAllUsers()
        {
            using var conn = Connection.OpenConnection();
            List<User> persons = new List<User>();
            string sql = "SELECT * FROM user;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql);
            while (rdr.Read())
            {
                persons.Add(new User(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetBoolean(5)));
            }
            rdr.Close();
            return persons;
        }

        public User GetUserById(int personId)
        {
            using var conn = Connection.OpenConnection();
            string sql = "SELECT * FROM user WHERE id = @ID";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("ID", personId));

            while (rdr.Read())
            {
                return new User(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetBoolean(5));
            }
            rdr.Close();
            return null;
        }

        public User GetUserByEmail(string email)
        {
            using var con = Connection.OpenConnection();
            string sql = "SELECT * FROM user WHERE email = @Email";
            var rdr = MySqlHelper.ExecuteReader(con, sql, new MySqlParameter("Email", email));
            while (rdr.Read())
            {
                return new User(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3),
                    rdr.GetString(4), rdr.GetBoolean(5));
            }
            rdr.Close();
            return null;
        }
    }
}
