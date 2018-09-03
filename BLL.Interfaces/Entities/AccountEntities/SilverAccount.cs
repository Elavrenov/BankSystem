using BLL.Interfaces.Entities.UserEntities;

namespace BLL.Interfaces.Entities.AccountEntities
{
    public sealed class SilverAccount:Account
    {
        #region const

        private const decimal AccountMultiply = 0.05M;

        #endregion

        #region ctor

        public SilverAccount(string id, AccountHolder accountHolder, decimal balance,int bonusPoint, AccountType accType)
            : base(id, accountHolder, balance,bonusPoint ,accType)
        {
        }

        #endregion

        #region Overrided Account methods

        protected override bool IsValidBalance(decimal value)
        {
            return value >= 0;
        }

        protected override int CalculateBonusPoints(decimal value)
        {
            return (int)(value * AccountMultiply + Balance / 1000);
        }

        #endregion
    }
}
