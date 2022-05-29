using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
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
            s.max_players,
            ts.id,
            ts.name
                FROM tournament AS t
                INNER JOIN sport AS s ON t.sport_id = s.id
            INNER JOIN tournament_system AS ts ON t.tournament_system_id = ts.id; ";
            var rdr = MySqlHelper.ExecuteReader(conn, sql);

            while (rdr.Read())
            {
                list.Add(new Tournament(rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetString(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetDateTime(5),
                    rdr.GetDateTime(6), SportFactory.CreateSport(new Sport(rdr.GetInt32(7), rdr.GetString(8), rdr.GetInt32(9),
                        rdr.GetInt32(10))), TournamentSystemFactory.CreateTournamentSystem(new TournamentSystem(rdr.GetInt32(11), rdr.GetString(12)))));
            }
            return list;
        }

        public List<TournamentView> GetAllTournamentsForView()
        {
            List<TournamentView> list = new();
            using var conn = Connection.OpenConnection();
            string sql = @"SELECT t.id, t.description, t.location, COUNT(ut.user_id), s.min_players, s.max_players, 
            t.start_date, t.end_date, s.name, ts.name
            FROM tournament AS t
             join sport s on t.sport_id = s.id
             join tournament_system ts on ts.id = t.tournament_system_id
             left join user_tournament AS ut
                  ON t.id = ut.tournament_id
                 group by (t.id);";
            var rdr = MySqlHelper.ExecuteReader(conn, sql);

            while (rdr.Read())
            {
                list.Add(new TournamentView(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2),
                    rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetDateTime(6),
                    rdr.GetDateTime(7), rdr.GetString(8), rdr.GetString(9)));
            }
            return list;
        }

        public List<User> GetAllUsersRegisteredToTournamentByTournamentId(int tournamentId)
        {
            List<User> users = new();
            using var conn = Connection.OpenConnection();
            string sql = @"select distinct id, first_name, last_name, email, password, is_admin from user as u
            join user_tournament ut on u.id = ut.user_id
            where tournament_id = @TournamentId;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("TournamentId", tournamentId));

            while (rdr.Read())
            {
                users.Add(new User(rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetBoolean(5)));
            }
            return users;
        }

        public List<int> GetAllStartedTournamentsIds()
        {
            List<int> ids = new();
            using var conn = Connection.OpenConnection();
            string sql = "select distinct tournament_id from user_tournament_match";
            var rdr = MySqlHelper.ExecuteReader(conn, sql);

            while (rdr.Read())
            {
                ids.Add(rdr.GetInt32(0));
            }
            return ids;
        }

        public Tournament GetTournamentLeaderboard(int tournamentId)
        {
            using var conn = Connection.OpenConnection();
            string sql2 = @"select * from result;";
            var rdr2 = MySqlHelper.ExecuteReader(conn, sql2);
            List<Result> results = new();
            while (rdr2.Read())
            {
                results.Add(new Result(rdr2.GetInt32(0), rdr2.GetInt32(1),
                    rdr2.GetInt32(2), rdr2.GetInt32(3)));
            }
            rdr2.Close();
            Dictionary<int, List<Result>> matchResults = new();
            foreach (var result in results.Where(result => !matchResults.ContainsKey(result.MatchId)))
            {
                matchResults.Add(result.MatchId, results.Where(x => x.MatchId == result.MatchId).ToList());
            }

            string sql = @"select distinct (m.id), m.date, utm1.tournament_id, utm1.user_id, utm2.user_id
            from `match` m
             join user_tournament_match utm1 on m.id = utm1.match_id
             join user_tournament_match utm2 on utm1.match_id = utm2.match_id
            join result r on m.id = r.match_id
            where utm1.tournament_id = @TournamentId
              and m.id = r.match_id
              AND utm1.user_id <> utm2.user_id
            group by m.id";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("TournamentId", tournamentId));
            List<Match> matches = new();
            while (rdr.Read())
            {
                var matchId = rdr.GetInt32(0);
                matches.Add(new Match(matchId, rdr.GetDateTime(1), rdr.GetInt32(2),
                    rdr.GetInt32(3), rdr.GetInt32(4), matchResults.Where(x => x.Key == matchId)
                        .Select(y => y.Value).First()));
            }
            rdr.Close();

            string sql3 = @"SELECT t.id,
            t.description,
            t.location,
            s.min_players,
            s.max_players,
            t.start_date,
            t.end_date,
            s.id,
            s.name,
            s.min_players,
            s.max_players,
            ts.id,
            ts.name,
            m.id,
            m.date,
            utm1.tournament_id,
            utm1.user_id,
            utm2.user_id
                FROM tournament AS t
                JOIN sport s ON t.sport_id = s.id
            JOIN tournament_system ts ON t.tournament_system_id = ts.id
            join user_tournament_match utm1 on t.id = utm1.tournament_id
            join user_tournament_match utm2 on t.id = utm2.tournament_id
            join `match` m on m.id = utm1.match_id
            where t.id = @TournamentId
            group by m.id;";

            var rdr3 = MySqlHelper.ExecuteReader(conn, sql3, new MySqlParameter("TournamentId", tournamentId));
            while (rdr3.Read())
            {
                return (new Tournament(rdr3.GetInt32(0), rdr3.GetString(1),
                    rdr3.GetString(2), rdr3.GetInt32(3), rdr3.GetInt32(4), rdr3.GetDateTime(5),
                    rdr3.GetDateTime(6), SportFactory.CreateSport(new Sport(rdr3.GetInt32(7), rdr3.GetString(8), rdr3.GetInt32(9),
                        rdr3.GetInt32(10))), TournamentSystemFactory.CreateTournamentSystem(new TournamentSystem(rdr3.GetInt32(11), rdr3.GetString(12))),
                            matches));
            }
            rdr3.Close();
            return null;
        }
    }
}
