using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Match
    {
        private int _id;
        private int _tournamentId;
        private List<Result> _results;
        private List<User> _users;

        public int Id { get=> _id; set =>_id = value; }
        public int TournamentId { get=> _tournamentId; set=>_tournamentId = value; }
        public List<Result> Results { get=>_results; set=>_results=value; }
        public List<User> Users { get=> _users; set=>_users=value; }

    }
}
