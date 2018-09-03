using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Model;

namespace ORM
{
    public class BankSystemContext:DbContext
    {
        public BankSystemContext() : base("BankSystem")
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountHolder> AccountHolders { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }
    }
}
