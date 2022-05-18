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
    public class ResultDB : IResultDB
    {
        public void CreateResult(Result r)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"INSERT INTO `result` (user_id, match_id, result) VALUE (@UserId, @MatchId, @Result);
            SELECT LAST_INSERT_ID();";
            var resultId = Convert.ToInt32(MySqlHelper.ExecuteScalar(conn, sql, new MySqlParameter("UserId", r.UserId),
                new MySqlParameter("MatchId", r.MatchId), new MySqlParameter("Result", r.MatchResult)));
        }

        public List<Result> GetAllResultsForTournament(int tournamentId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select r.id, r.user_id, r.match_id, r.result
            from result r
                     join `match` m on m.id = r.match_id
                     join user_tournament_match utm on m.id = utm.match_id
            where utm.tournament_id = @TournamentId
            group by r.id, r.user_id, r.match_id, r.result";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("TournamentId", tournamentId));

            List<Result> results = new();
            while (rdr.Read())
            {
                results.Add(new Result(rdr.GetInt32(0), rdr.GetInt32(1),
                    rdr.GetInt32(2), rdr.GetString(3)));
            }
            return results;
        }

        public List<Result> GetAllResultsPerMatchById(int matchId, int userId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select * from result
            where match_id = @MatchId
            order by user_id = @UserId;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("MatchId", matchId),
                new MySqlParameter("UserId", userId));

            List<Result> results = new();
            while (rdr.Read())
            {
                results.Add(new Result(rdr.GetInt32(0), rdr.GetInt32(1),
                    rdr.GetInt32(2), rdr.GetString(3)));
            }
            return results;
        }
    }
}
