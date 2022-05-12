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

        public UserService(IUserDB repository)
        {
            _repository = repository;
        }

        public void AddUser(User u) => _repository.AddUser(u, Hashing.HashPassword(u.Password));
        public void UpdateUser(User u) => _repository.UpdateUser(u);
        public void DeleteUser(User u) => _repository.DeleteUser(u);
        public List<User> GetAllUsers() => _repository.GetAllUsers();
        public User GetUserById(int id) => _repository.GetUserById(id);
        public User GetUserByEmail(string email) => _repository.GetUserByEmail(email);

        public void RegisterUserToTournament(int userId, int tournamentId) =>
            _repository.RegisterUserToTournament(userId, tournamentId);

    }
}
