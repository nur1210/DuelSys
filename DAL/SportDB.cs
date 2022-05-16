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
    public class SportDB : ISportDB
    {
        public Sport GetSportById(int sportId)
        {
            using var conn = Connection.OpenConnection();
            string sql = "SELECT * FROM sport WHERE id = @Id;";
            var rdr = MySqlHelper.ExecuteReader(conn, sql, new MySqlParameter("Id", sportId));

            while (rdr.Read())
            {
                return SportFactory.CreateSport(new Sport(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3)));
            }
            return null;
        }

        public List<Sport> GetAllSports()
        {
            List<Sport> list = new();
            using var conn = Connection.OpenConnection();
            string sql = "SELECT * FROM sport";
            var rdr = MySqlHelper.ExecuteReader(conn, sql);

            while (rdr.Read())
            {
                list.Add(SportFactory.CreateSport(new Sport(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(3))));
            }
            return list;
        }
    }
}
