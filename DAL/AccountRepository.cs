using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Interfaces.DTO;
using ORM.Model;
using Account = BLL.Interfaces.Entities.AccountEntities.Account;
using AccountType = BLL.Interfaces.Entities.AccountEntities.AccountType;

namespace DAL
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbContext _dbContext;

        public AccountRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #region Interface implementation

        public void CreateAccount(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var accountOwner = GetAccountOwner(account);
            _dbContext.Set<AccountHolder>().Add(accountOwner);

            //////////////////TODO
        }

        public void UpdateAccount(DalAccount account)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(DalAccount account)
        {
            throw new NotImplementedException();
        }

        public DalAccount GetAccount(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAccount> GetAccounts()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private

        private static AccountType GetAccountType(DalAccount account)
        {
            if (account.Type.Contains("Gold"))
            {
                return AccountType.Gold;
            }

            if (account.Type.Contains("Platinum"))
            {
                return AccountType.Platinum;
            }

            if (account.Type.Contains("Silver"))
            {
                return AccountType.Silver;
            }

            return AccountType.Base;
        }

        private static AccountHolder GetAccountOwner(DalAccount account) =>
            new AccountHolder()
            {
                Email = account.AccountHolder.EmailAddress,
                FirstName = account.AccountHolder.FirstName,
                SecondName = account.AccountHolder.SecondName
            };

        #endregion
    }
}
