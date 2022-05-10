using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Services
{
    public class Validation
    {
        private readonly IUserDB _repository;

        public Validation(IUserDB repository)
        {
            _repository = repository;
        }

        public bool ValidUser(string email, string password)
        {
            if (_repository.GetUserByEmail(email) == null) return false;
            var user = _repository.GetUserByEmail(email);
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
    }
}
