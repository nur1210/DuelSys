using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class Validation
    {
        private readonly IUserDB _userRepository;
        private readonly TournamentService _tournamentService;

        public Validation(IUserDB userRepository, TournamentService tournamentService)
        {
            _userRepository = userRepository;
            _tournamentService = tournamentService;
        }

        public bool ValidUser(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) == null) return false;
            var user = _userRepository.GetUserByEmail(email);
            return Hashing.ValidatePassword(password, user.Password);
        }

        public bool ValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidTournamentRegistration(int userId, int tournamentId)
        {
            var tournament = _tournamentService.GetTournamentById(tournamentId);
            return _tournamentService.GetAllUsersRegisteredToTournamentByTournamentId(tournamentId)
                .All(user => user.Id != userId && tournament.StartDate > DateTime.Now.AddDays(7) &&
                             !_tournamentService.TournamentHasStarted(tournamentId));
        }

        public bool ValidatePassword(string CurrentPassword, string userPassword)
        {
            return Hashing.ValidatePassword(CurrentPassword, userPassword);
        }
    }
}
