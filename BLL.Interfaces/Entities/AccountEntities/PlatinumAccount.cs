using BLL.Interfaces.Entities.UserEntities;

namespace BLL.Interfaces.Entities.AccountEntities
{
    public sealed class PlatinumAccount : Account
    {
        #region const

        private const decimal AccountMultiply = 0.50M;

        #endregion

        #region ctor

        public PlatinumAccount(string id, AccountHolder accountHolder, decimal balance, int bonusPoint, AccountType accType)
            : base(id, accountHolder, balance, bonusPoint, accType)
        {
        }

        #endregion

        #region Overrided Account methods

        protected override bool IsValidBalance(decimal value)
        {
            return value > -1_000_000;
        }

        protected override int CalculateBonusPoints(decimal value)
        {
            return (int)(value * AccountMultiply + Balance / 1000);
        }

        #endregion
    }
}
