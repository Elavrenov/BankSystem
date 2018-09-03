using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Model
{
    public class Account
    {
        public string AccountId { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }

        public int AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }

        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
    }
}
