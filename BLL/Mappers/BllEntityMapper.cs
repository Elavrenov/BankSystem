using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities.AccountEntities;
using BLL.Interfaces.Entities.UserEntities;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    internal static class BllEntityMapper
    {
        public static DalAccountHolder ToDalAccountHolder(this AccountHolder holder, string encryptedPassword) =>
            new DalAccountHolder
            {
                FirstName = holder.FirstName,
                SecondName = holder.SecondName,
                Email = holder.EmailAddress,
                EncryptedPassword = encryptedPassword,
                Role = holder.Role
            };

        public static AccountHolder ToInterfaceBankUser(this DalAccountHolder dalHolder)
        {
            var result = new AccountHolder
            {
                EmailAddress = dalHolder.Email,
                FirstName = dalHolder.FirstName,
                SecondName = dalHolder.SecondName,
                Role = dalHolder.Role
            };

            result.Accounts.AddRange(dalHolder.Accounts.Select(account => account.ToBllAccount()));
            return result;
        }

        internal static DalAccount ToDalAccount(this Account account) =>
            new DalAccount
            {
                Type = account.GetType().Name,
                BonusPoints = account.BonusPoints,
                Balance = account.Balance,
                Id = account.Id,
                AccountHolder = account.AccountHolder
            };

        internal static Account ToBllAccount(this DalAccount dalAccount) =>
            (Account) Activator.CreateInstance(
                GetBllAccountType(dalAccount.Type),
                dalAccount.Id,
                dalAccount.AccountHolder,
                dalAccount.Balance,
                dalAccount.BonusPoints);

        private static Type GetBllAccountType(string type)
        {
            if (type.Contains("Gold"))
            {
                return typeof(GoldAccount);
            }

            if (type.Contains("Silver"))
            {
                return typeof(SilverAccount);
            }

            if (type.Contains("Platinum"))
            {
                return typeof(PlatinumAccount);
            }

            return typeof(BaseAccount);
        }
    }
}
