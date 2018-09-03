using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.AccountIdServices;
using BLL.Interfaces.Entities.AccountEntities;
using BLL.Interfaces.Entities.UserEntities;

namespace BLL.Interfaces.AccountServices
{
    public interface IAccountService
    {
        string OpenAccount(AccountHolder bankUser, IAccountIdGenerator idGenerator, decimal sum, AccountType accountType = AccountType.Base);
        void CloseAccount(string accountId);
        void DepositMoney(string accountId, decimal sum);
        void WithdrawMoney(string accountId, decimal sum);
        Account GetAccountInfo(string accountId);

    }
}
