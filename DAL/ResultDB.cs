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
            string sql = @"INSERT INTO `result` (user_id, result) VALUE (@UserId, @Result);
            SELECT LAST_INSERT_ID();";
            var resultId = Convert.ToInt32(MySqlHelper.ExecuteScalar(conn, sql, new MySqlParameter("UserId", r.UserId),
                new MySqlParameter("Result", r.MatchResult)));

            string sql2 = "INSERT into match_result (match_id, result_id) VALUES (@MatchId, @ResultId)";
            MySqlHelper.ExecuteNonQuery(conn, sql2, new MySqlParameter("MatchId", r.MatchId),
                new MySqlParameter("ResultId", resultId));
        }

        public List<Result> GetAllResultsForTournament(int tournamentId)
        {
            using var conn = Connection.OpenConnection();
            string sql = @"select r.id, r.user_id, mr.match_id, r.result from result r
            join match_result mr on r.id = mr.result_id
            join `match` m on m.id = mr.match_id
            join user_tournament_match utm on m.id = utm.match_id
            where utm.tournament_id = @TournamentId";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("TournamentId", tournamentId));

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
