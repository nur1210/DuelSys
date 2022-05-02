using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Person
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;

        public int Id { get=> _id;}
        public string FirstName { get=> _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; private set => _password = value; }

    }
}
