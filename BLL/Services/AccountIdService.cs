using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.AccountIdServices;
using BLL.Interfaces.Entities.AccountEntities;
using BLL.Interfaces.Entities.UserEntities;

namespace BLL.Services
{
    public class AccountIdService : IAccountIdGenerator
    {
        public string GenerateAccountId(string email)
        {
            StringBuilder sb = new StringBuilder(10);
            sb.Append(email.GetHashCode());
            Random rd = new Random();

            for (int i = 0; i < sb.Length-2; i+=2)
            {
                sb[i] =(char)rd.Next(10);
            }

            sb.Remove(10, sb.Length);
            return sb.ToString();
        }

    }
}
