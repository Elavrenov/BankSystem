using BLL.Interfaces.Entities.UserEntities;

namespace BLL.Interfaces.Entities.AccountEntities
{
    public sealed class BaseAccount : Account
    {
        #region const

        private const decimal AccountMultiply = 0.01M;

        #endregion

        #region ctor

        public BaseAccount(string id, AccountHolder accountHolder, decimal balance, int bonusPoint, AccountType accType)
            : base(id, accountHolder, balance, bonusPoint, accType)
        {
        }

        #endregion

        #region Ovverrided Account methods

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
