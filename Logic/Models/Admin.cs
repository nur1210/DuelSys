using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Admin: Person
    {
        public Admin(string firstName, string lastName, string email, string password, bool isAdmin) : base(firstName, lastName, email, password, isAdmin)
        {
        }

        public Admin(int id, string firstName, string lastName, string email, string password, bool isAdmin) : base(id, firstName, lastName, email, password, isAdmin)
        {
        }
    }
}
