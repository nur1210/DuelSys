using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class UserService
    {
        private readonly IUserDB _repository;
        private readonly ITournamentDB _tournamentRepository;

        public UserService(IUserDB repository, ITournamentDB tournamentRepository)
        {
            _repository = repository;
            _tournamentRepository = tournamentRepository;
        }

        public void AddUser(User u) => _repository.AddUser(u, Hashing.HashPassword(u.Password));
        public void UpdateUser(User u) => _repository.UpdateUser(u);
        public void UpdateUserPassword(User u) => _repository.UpdateUser(u, Hashing.HashPassword(u.Password));
        public void DeleteUser(User u) => _repository.DeleteUser(u);
        public List<User> GetAllUsers() => _repository.GetAllUsers();
        public User GetUserById(int id) => _repository.GetUserById(id);
        public User GetUserByEmail(string email) => _repository.GetUserByEmail(email);

        public bool RegisterUserToTournament(int userId, int tournamentId)
        {
            var tournament = _tournamentRepository.GetAllTournaments().First(t => t.Id == tournamentId);
            if (tournament.StartDate <= DateTime.Now.AddDays(7)) return false;
            _repository.RegisterUserToTournament(userId, tournamentId);
            return true;
        }

        public Dictionary<int, string> GetAllUsersIdAndFullName() => _repository.GetAllUsersIdAndFullName();

        public List<string> GetAllRegisteredTournamentsNamesPerUser(int userId) =>
            _repository.GetAllRegisteredTournamentsNamesPerUser(userId);

        public DateTime GetUpcomingMatchDate(int userId) => _repository.GetUpcomingMatchDate(userId);

        public int GetUserBestRank(int userId)
        {
            var tournamentsIds = _tournamentRepository.GetAllTournaments().Select(t => t.Id).ToList();
            var allLeaderboards = tournamentsIds.Select(id => _tournamentRepository.GetTournamentLeaderboard(id)).ToList();
            var bestRank = 100;
            foreach (var leaderboard in allLeaderboards)
            {
                int? userRank = leaderboard.RankedLeaderboard.Where(x => x.Value.UserId == userId)
                    .Select(y => y.Key)
                    .FirstOrDefault();
                if (bestRank > userRank && userRank is > 0)
                {
                    bestRank = leaderboard.RankedLeaderboard
                        .Where(x => x.Value.UserId == userId)
                        .Select(y => y.Key)
                        .First();
                }
            }
            if (bestRank == 100)
            {
                throw new ArgumentException("User is not ranked");
            }

            return bestRank;
        }

        public List<Tournament> GetAllTournamentsPerUser(int userId) =>
            _repository.GetAllTournamentsPerUser(userId);
    }
}
