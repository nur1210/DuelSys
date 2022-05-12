using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using Logic.Views;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class TournamentDB : ITournamentDB
    {
        public void CreateTournament(Tournament t)
        {
            using var conn = Connection.OpenConnection();
            string sql = "INSERT INTO tournament (description, location, start_date, end_date, sport_id, tournament_system_id) " +
                         "VALUES (@Description, @Location, @StartDate, @EndDate, @SportId, @TournamentSystemId);";
            MySqlHelper.ExecuteNonQuery(conn, sql, new MySqlParameter("Description", t.Description), new MySqlParameter("Location", t.Location),
                new MySqlParameter("StartDate", t.StartDate), new MySqlParameter("EndDate", t.EndDate), new MySqlParameter("SportId", t.Sport.Id),
                new MySqlParameter("TournamentSystemId", t.System.Id));
        }

        public void UpdateTournament(Tournament t, int tournamentId)
        {
            using var conn = Connection.OpenConnection();
            string sql = "UPDATE tournament SET description = @Description, location = @Location, start_date = @StartDate, " +
                         "end_date = @EndDate, sport_id = @SportId, tournament_system_id = @TournamentSystemId WHERE id = @Id ;";
            MySqlHelper.ExecuteNonQuery(conn, sql, new MySqlParameter("Description", t.Description), new MySqlParameter("Location", t.Location),
                new MySqlParameter("StartDate", t.StartDate), new MySqlParameter("EndDate", t.EndDate), new MySqlParameter("SportId", t.Sport.Id),
                new MySqlParameter("TournamentSystemId", t.System.Id), new MySqlParameter("Id", tournamentId));
        }

        public void DeleteTournament(int tournamentId)
        {
            using var conn = Connection.OpenConnection();
            string sql = "DELETE * FROM tournament WHERE id = @Id;";
            MySqlHelper.ExecuteNonQuery(conn, sql, new MySqlParameter("Id", tournamentId));
        }

        public List<Tournament> GetAllTournaments()
        {
            List<Tournament> list = new();
            using var conn = Connection.OpenConnection();
            string sql = "SELECT t.id, t.description, t.location, s.min_players, s.max_players, t.start_date, " +
                         "t.end_date, s.id, s.name, s.min_players, s.max_players, ts.id, ts.name FROM tournament AS t " +
                         "INNER JOIN sport AS s ON t.sport_id = s.id INNER JOIN tournament_system AS ts " +
                         "ON t.tournament_system_id = ts.id;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql);

            while (rdr.Read())
            {
                list.Add(new Tournament(rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetDateTime(5),
                    rdr.GetDateTime(6), new SportDTO(rdr.GetInt32(7), rdr.GetString(8), rdr.GetInt32(9),
                        rdr.GetInt32(10)), new TournamentSystemDTO(rdr.GetInt32(11), rdr.GetString(12))));
            }
            return list;
        }

        public List<TournamentView> GetAllTournamentsForView()
        {
            List<TournamentView> list = new();
            using var conn = Connection.OpenConnection();
            string sql = @"SELECT t.description, t.location, COUNT(utm.user_id), s.min_players, s.max_players, 
            t.start_date, t.end_date, s.name, ts.name
            FROM tournament AS t
             join sport s on t.sport_id = s.id
             join tournament_system ts on ts.id = t.tournament_system_id
             left join user_tournament_match AS utm
                  ON t.id = utm.tournament_id
                 group by (t.id);";
            var rdr = MySqlHelper.ExecuteReader(conn, sql);

            while (rdr.Read())
            {
                list.Add(new TournamentView(rdr.GetString(0), rdr.GetString(1),
                    rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetDateTime(5),
                    rdr.GetDateTime(6), rdr.GetString(7), rdr.GetString(8)));
            }
            return list;
        }
    }
}
