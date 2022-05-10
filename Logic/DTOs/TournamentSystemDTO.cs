using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic.DTOs
{
    public class TournamentSystemDTO
    {
        private int _id;
        private string _name;
        //private List<Match> _matches;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        //public List<Match> Matches { get => _matches; set => _matches = value; }

        public TournamentSystemDTO(int id, string name)
        {
            _id = id;
            _name = name;
           // _matches = matches;
        }
    }
}
