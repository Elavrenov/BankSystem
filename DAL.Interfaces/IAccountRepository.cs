using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces
{
    public interface IAccountRepository
    {
        void CreateAccount(DalAccount account);
        void UpdateAccount(DalAccount account);
        void RemoveAccount(DalAccount account);
        DalAccount GetAccount(string id);
        IEnumerable<DalAccount> GetAccounts();

    }
}
