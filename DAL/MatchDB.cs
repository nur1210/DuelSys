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
    public class MatchDB : IMatchDB
    {

        public void CreateMatch(Match m)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"INSERT INTO `match` (date) VALUE (@Date);
            SELECT LAST_INSERT_ID();";
            var matchId = Convert.ToInt32(MySqlHelper.ExecuteScalar(conn, sql, new MySqlParameter("Date", m.Date)));

            string sql2 = "INSERT into user_tournament_match (user_id, tournament_id, match_id) VALUES (@UserId, @TournamentId, @MatchId)";
            MySqlHelper.ExecuteNonQuery(conn, sql2, new MySqlParameter("UserId", m.FirstPlayerId),
                new MySqlParameter("TournamentId", m.TournamentId), new MySqlParameter("MatchId", matchId));

            string sql3 = "INSERT into user_tournament_match (user_id, tournament_id, match_id) VALUES (@UserId, @TournamentId, @MatchId)";
            MySqlHelper.ExecuteNonQuery(conn, sql3, new MySqlParameter("UserId", m.SecondPlayerId),
                new MySqlParameter("TournamentId", m.TournamentId), new MySqlParameter("MatchId", matchId));
        }

        public List<Match> GetAllMatchesForTournament(int tournamentId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select distinct (m.id), m.date, utm1.tournament_id, utm1.user_id, utm2.user_id
            from `match` m
             join user_tournament_match utm1 on m.id = utm1.match_id
             join user_tournament_match utm2 on utm1.match_id = utm2.match_id
            where utm1.tournament_id = @TournamentId
              AND utm1.user_id <> utm2.user_id
            group by m.id";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("TournamentId", tournamentId));

            List<Match> matches = new();
            while (rdr.Read())
            {
                matches.Add(new Match(rdr.GetInt32(0), rdr.GetDateTime(1), rdr.GetInt32(2),
                    rdr.GetInt32(3), rdr.GetInt32(4)));
            }
            return matches;
        }

        public Dictionary<int, List<Match>> GetAllMatchesPerPlayer(int tournamentId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select distinct (m.id), m.date, utm1.tournament_id, utm1.user_id, utm2.user_id
            from `match` m
             join user_tournament_match utm1 on m.id = utm1.match_id
             join user_tournament_match utm2 on utm1.match_id = utm2.match_id
            where utm1.tournament_id = @TournamentId
              AND utm1.user_id <> utm2.user_id";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("TournamentId", tournamentId));
            List<Match> matches = new();
            while (rdr.Read())
            {
                matches.Add(new Match(rdr.GetInt32(0), rdr.GetDateTime(1), rdr.GetInt32(2),
                    rdr.GetInt32(3), rdr.GetInt32(4)));
            }
            rdr.Close();

            string sql2 = @"select distinct id from user as u
            join user_tournament ut on u.id = ut.user_id
            where tournament_id = @TournamentId;";
            var rdr2 = MySqlHelper.ExecuteReader(conn, sql2, new MySqlParameter("TournamentId", tournamentId));
            Dictionary<int, List<Match>> playerMatches = new();
            while (rdr2.Read())
            {
                var id = rdr2.GetInt32(0);
                playerMatches.Add(id, matches.FindAll(x => x.FirstPlayerId == id));
            }
            rdr2.Close();
            return playerMatches;
        }

        public bool HasResult(int matchId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select * from result where match_id = @MatchId;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("MatchId", matchId));
            return rdr.HasRows;
        }

        public Match GetMatchByUsersIds(int firstUserId, int secondUserId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select m.id, m.date, utm1.tournament_id, utm1.user_id, utm2.user_id from `match` m
            join user_tournament_match utm1 on m.id = utm1.match_id
            join user_tournament_match utm2 on utm1.match_id = utm2.match_id
            where utm1.user_id = @FirstUserId AND utm2.user_id = @SecondUserId;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("FirstUserId", firstUserId),
                new MySqlParameter("SecondUserId", secondUserId));
            while (rdr.Read())
            {
                return new Match(rdr.GetInt32(0), rdr.GetDateTime(1), rdr.GetInt32(2),
                    rdr.GetInt32(3), rdr.GetInt32(4));
            }
            return null;
        }

        public List<Match> GetAllPlayedMatchesPerTournament(int tournamentId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select distinct (m.id), m.date, utm1.tournament_id, utm1.user_id, utm2.user_id
            from `match` m
             join user_tournament_match utm1 on m.id = utm1.match_id
             join user_tournament_match utm2 on utm1.match_id = utm2.match_id
            join result r on m.id = r.match_id
            where utm1.tournament_id = @TournamentId
              and m.id = r.match_id
              AND utm1.user_id <> utm2.user_id
            group by m.id";

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
            return matches;
        }
    }
}
