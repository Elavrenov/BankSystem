using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities.UserEntities;

namespace BLL.IdGenerator
{
    public interface IAccountIdGenerator
    {
        string GenerateAccountId(AccountHolder accountHolder);
    }
}
