using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Exceptions;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserDB : IUserDB
    {
        public void AddUser(User user, string hashPassword)
        {
            using var conn = Connection.OpenConnection();
            string sql =
                "INSERT INTO user (first_name, last_name, email, password, is_admin) VALUES (@FirstName, @LastName, @Email, @Password, @IsAdmin)";
            MySqlHelper.ExecuteNonQuery(conn, sql, new MySqlParameter("FirstName", user.FirstName),
                new MySqlParameter("LastName", user.LastName), new MySqlParameter("Email", user.Email),
                new MySqlParameter("Password", hashPassword), new MySqlParameter("IsAdmin", user.IsAdmin));
        }

        public void UpdateUser(User user)
        {
            using var conn = Connection.OpenConnection();
            string sql =
                "UPDATE user SET first_name = @FirstName, last_name = @LastName, email = @Email WHERE id = @ID ";
            MySqlHelper.ExecuteNonQuery(conn, sql, new MySqlParameter("FirstName", user.FirstName),
                new MySqlParameter("LastName", user.LastName),
                new MySqlParameter("Email", user.Email), new MySqlParameter("ID", user.Id));
        }

        public void UpdateUser(User user, string hashPassword)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"UPDATE user
            SET first_name = @FirstName,
                last_name = @LastName,
                email = @Email,
                password = @Password
            WHERE id = @ID;";
            MySqlHelper.ExecuteNonQuery(conn, sql, new MySqlParameter("FirstName", user.FirstName),
                new MySqlParameter("LastName", user.LastName), new MySqlParameter("Email", user.Email),
                new MySqlParameter("Password", hashPassword), new MySqlParameter("ID", user.Id));
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
                persons.Add(new User(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3),
                    rdr.GetString(4), rdr.GetBoolean(5)));
            }

            rdr.Close();
            return persons;
        }

        public User GetUserById(int userId)
        {
            using var conn = Connection.OpenConnection();
            string sql = "SELECT * FROM user WHERE id = @ID";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("ID", userId));

            while (rdr.Read())
            {
                return new User(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4),
                    rdr.GetBoolean(5));
            }

            rdr.Close();
            return null;
        }

        public User GetUserByEmail(string email)
        {
            using var con = Connection.OpenConnection();
            string sql = "SELECT * FROM user WHERE email = @Email";
            var rdr = MySqlHelper.ExecuteReader(con, sql, new MySqlParameter("Email", email));
            rdr.Read();
            if (rdr.HasRows)
            {
                return new User(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3),
                    rdr.GetString(4), rdr.GetBoolean(5));
            }
            throw new NotFoundException("User not found");
        }

        public void RegisterUserToTournament(int userId, int tournamentId)
        {
            using var conn = Connection.OpenConnection();
            try
            {
                string sql = "INSERT INTO user_tournament (user_id, tournament_id) VALUES (@UserId, @TournamentId)";
                MySqlHelper.ExecuteNonQuery(conn, sql, new MySqlParameter("UserId", userId), new MySqlParameter("TournamentId", tournamentId));
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public Dictionary<int, string> GetAllUsersIdAndFullName()
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select id, concat(first_name,' ',last_name) full_name from user;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql);
            Dictionary<int, string> userIdAndName = new();
            while (rdr.Read())
            {
                userIdAndName.Add(rdr.GetInt32(0), rdr.GetString(1));
            }
            rdr.Close();
            return userIdAndName;
        }

        public List<string> GetAllRegisteredTournamentsNamesPerUser(int userId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select description from tournament
                            join user_tournament on tournament.id = user_tournament.tournament_id
                            where user_tournament.user_id = @UserId;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("UserId", userId));
            List<string> tournamentsNames = new();
            while (rdr.Read())
            {
                tournamentsNames.Add(rdr.GetString(0));
            }
            rdr.Close();
            return tournamentsNames;
        }

        public DateTime GetUpcomingMatchDate(int userId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select date from tournament
                                     join user_tournament_match utm on tournament.id = utm.tournament_id
                                     join `match` m on m.id = utm.match_id
                            where utm.user_id = @UserId
                              and m.date > now()
                            order by m.date asc
                            limit 1;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("UserId", userId));
            if (!rdr.HasRows)
            {
                rdr.Close();
                throw new NotFoundException("No upcoming matches");
            }

            rdr.Read();
            return rdr.GetDateTime(0);
        }

        public List<Tournament> GetAllTournamentsPerUser(int userId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"SELECT t.id,
               t.description,
               t.location,
               s.min_players,
               s.max_players,
               t.start_date,
               t.end_date,
               s.id,
               s.name,
               s.min_players,
               s.max_players
        FROM tournament AS t
                 INNER JOIN sport AS s ON t.sport_id = s.id
                 join user_tournament_match utm on t.id = utm.tournament_id
        where utm.user_id = @UserId
        group by t.id;"; ;
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("UserId", userId));
            List<Tournament> list = new();
            while (rdr.Read())
            {
                list.Add(new Tournament(rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetDateTime(5),
                    rdr.GetDateTime(6), SportFactory.CreateSport(new Sport(rdr.GetInt32(7), rdr.GetString(8), rdr.GetInt32(9),
                        rdr.GetInt32(10))), TournamentSystemFactory.CreateTournamentSystem(new TournamentSystem(rdr.GetInt32(11), rdr.GetString(12)))));
            }
            return list;
        }
    }
}
