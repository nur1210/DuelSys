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
            var matchId = Convert.ToInt32(MySqlHelper.ExecuteScalar(conn, sql, new MySqlParameter("Date", null)));

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
            string sql = @"select distinct (m.id), utm1.tournament_id, utm1.user_id, utm2.user_id from `match` m
            join user_tournament_match utm1 on m.id = utm1.match_id
            join user_tournament_match utm2 on utm1.match_id = utm2.match_id
            where utm1.tournament_id = @TournamentId
            AND utm1.user_id <> utm2.user_id
            group by m.id";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("TournamentId", tournamentId));

            List<Match> matches = new();
            while (rdr.Read())
            {
                matches.Add(new Match(rdr.GetInt32(0), rdr.GetInt32(1),
                    rdr.GetInt32(2), rdr.GetInt32(3)));
            }
            return matches;
        }
    }
}
