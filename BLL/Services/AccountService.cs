using System;
using BLL.Interfaces.AccountIdServices;
using BLL.Interfaces.AccountServices;
using BLL.Interfaces.Entities.AccountEntities;
using BLL.Interfaces.Entities.UserEntities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        /// <summary>
        /// TODO///////////////////
        /// </summary>
        #region private fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;

        #endregion

        #region ctor

        public AccountService(IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        
        #endregion                
        public string OpenAccount(AccountHolder bankUser, IAccountIdGenerator idGenerator, decimal sum,
            AccountType accountType = AccountType.Base)
        {
            throw new System.NotImplementedException();
        }

        public void CloseAccount(string accountId)
        {
            throw new System.NotImplementedException();
        }

        public void DepositMoney(string accountId, decimal sum)
        {
            throw new System.NotImplementedException();
        }

        public void WithdrawMoney(string accountId, decimal sum)
        {
            throw new System.NotImplementedException();
        }

        public Account GetAccountInfo(string accountId)
        {
            throw new System.NotImplementedException();
        }
    }
}
