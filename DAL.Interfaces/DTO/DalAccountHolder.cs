using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DalAccountHolder
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

        public string EncryptedPassword { get; set; }

        public string Role { get; set; }

        public List<DalAccount> Accounts { get; set; } = new List<DalAccount>();
    }
}
