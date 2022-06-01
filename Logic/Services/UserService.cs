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

        public Leaderboard GetTournamnetLeaderboard(int tournamentId, List<User> tournamentPlayers) =>
            _repository.GetTournamnetLeaderboard(tournamentId, tournamentPlayers);
    }
}
