using System;
using BLL.Interfaces.Entities.UserEntities;

namespace BLL.Interfaces.Entities.AccountEntities
{
    public abstract class Account : IComparable, IComparable<Account>, IEquatable<Account>
    {

        #region Private fields

        private string _id;
        private AccountHolder _accountHolder;
        private decimal _balance;
        private int _bonusPoints;

        #endregion

        #region ctors

        protected Account()
        {
        }

        protected Account(string id, AccountHolder accountHolder, decimal balance, int bonusPoints, AccountType accountType)
        {
            Id = id;
            AccountHolder = accountHolder;
            Balance = balance;
            BonusPoints = bonusPoints;
            AccountType = accountType;
        }
        #endregion

        #region prop

        public AccountType AccountType { get; set; }
        public string Id
        {
            get => _id;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid id.", nameof(this.Id));
                }

                _id = value;
            }
        }

        public decimal Balance
        {
            get => _balance;
            private set
            {
                if (!IsValidBalance(value))
                {
                    throw new ArgumentException(nameof(value));
                }

                _balance = value;
            }
        }

        public int BonusPoints
        {
            get => _bonusPoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }

                _bonusPoints = value;
            }
        }

        public AccountHolder AccountHolder
        {
            get => _accountHolder;
            set => _accountHolder = value ?? throw new ArgumentNullException(nameof(this.AccountHolder));
        }

        #endregion

        #region Interfaces implementation

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            return obj.GetType() != this.GetType() ? 1 : this.CompareTo((Account)obj);
        }

        public int CompareTo(Account other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return other.Id == Id ? 0 : -1;
        }

        public bool Equals(Account other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return Id == other.Id;
        }
        #endregion

        #region Overrided object methods

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return obj.GetType() == this.GetType() && this.Equals((Account)obj);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() =>
            $"{AccountType} {Id} " +
            $"{AccountHolder.FirstName} {AccountHolder.SecondName} {Balance} " +
            $"{BonusPoints} {AccountHolder.EmailAddress}";

        #endregion

        #region Public API

        public void Deposit(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(value));
            }

            Balance += value;
            BonusPoints += CalculateBonusPoints(value);
        }
        public void WithDraw(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(value));
            }

            Balance -= value;
            BonusPoints -= CalculateBonusPoints(value);
        }

        #endregion

        #region Abstract methods

        protected abstract bool IsValidBalance(decimal value);
        protected abstract int CalculateBonusPoints(decimal value);

        #endregion

    }
}
