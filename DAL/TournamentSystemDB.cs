using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class TournamentSystemDB : ITournamentSystemDB
    {
        public TournamentSystem GetTournamentSystemById(int systemId)
        {
            using var conn = Connection.OpenConnection();
            string sql = "SELECT * FROM tournament_system WHERE id = @Id;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("Id", systemId));

            while (rdr.Read())
            {
                return TournamentSystemFactory.CreateTournamentSystem(new TournamentSystem(rdr.GetInt32(0), rdr.GetString(1)));
            }
            return null;
        }

        public List<TournamentSystem> GetAllTournamentSystems()
        {
            List<TournamentSystem> list = new();
            using var conn = Connection.OpenConnection();
            string sql = "SELECT * FROM tournament_system";
            var rdr = MySqlHelper.ExecuteReader(conn, sql);

            while (rdr.Read())
            {
                list.Add(TournamentSystemFactory.CreateTournamentSystem(new TournamentSystem(rdr.GetInt32(0), rdr.GetString(1))));
            }
            return list;
        }
    }
}

