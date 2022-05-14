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
    }
}
