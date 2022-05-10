using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTOs;
using Logic.Interfaces;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class TournamentSystemDB : ITournamentSystemDB
    {
        public TournamentSystemDTO GetTournamentSystemById(int systemId)
        {
            using var conn = Connection.OpenConnection();
            string sql = "SELECT * FROM tournament_system WHERE id = @Id;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("Id", systemId));

            while (rdr.Read())
            {
                return new TournamentSystemDTO(rdr.GetInt32(0), rdr.GetString(1));
            }
            return null;
        }

        public List<TournamentSystemDTO> GetAllTournamentSystems()
        {
            List<TournamentSystemDTO> list = new();
            using var conn = Connection.OpenConnection();
            string sql = "SELECT * FROM tournament_system";
            var rdr = MySqlHelper.ExecuteReader(conn, sql);

            while (rdr.Read())
            {
                list.Add(new TournamentSystemDTO(rdr.GetInt32(0), rdr.GetString(1)));
            }
            return list;
        }
    }
}

