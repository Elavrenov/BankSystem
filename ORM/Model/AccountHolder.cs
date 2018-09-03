using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Model
{
    public class AccountHolder
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string EncryptedPassword { get; set; }
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
