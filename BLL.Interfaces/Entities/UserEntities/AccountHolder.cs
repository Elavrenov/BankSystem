using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities.AccountEntities;

namespace BLL.Interfaces.Entities.UserEntities
{
    public class AccountHolder : IComparable, IComparable<AccountHolder>, IEquatable<AccountHolder>
    {
        #region Private fields

        private const string DefaultRole = "user";
        private string _firstName;
        private string _secondName;
        private string _emailAddress;
        private string _role;

        #endregion

        #region ctors

        public AccountHolder()
        {
            _role = DefaultRole;
        }
        public AccountHolder(string firstName, string secondName, string emailAddress, string role = "user")
        {
            VerifyString(firstName);
            VerifyString(secondName);
            VerifyEmail(emailAddress);
            VerifyString(role);

            _firstName = firstName;
            _secondName = secondName;
            _emailAddress = emailAddress;
            _role = role;
        }

        #endregion

        #region prop

        public string FirstName
        {
            get => _firstName;
            set
            {
                VerifyString(value);
                _firstName = value;
            }
        }

        public string SecondName
        {
            get => _secondName;
            set
            {
                VerifyString(value);
                _secondName = value;
            }
        }
        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                VerifyString(value);
                VerifyEmail(value);
                _emailAddress = value;
            }
        }
        public string Role
        {
            get => _role;
            set
            {
                VerifyString(value);
                _role = value;
            }
        }

        public List<Account> Accounts { get; set; } = new List<Account>();
        #endregion

        #region Interfaces implementation

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            return obj.GetType() == this.GetType() ? this.CompareTo((AccountHolder)obj) : 1;
        }

        public int CompareTo(AccountHolder other)
        {
            return other is null ? 1 : string.Compare(other.EmailAddress, this.EmailAddress, StringComparison.Ordinal);
        }

        public bool Equals(AccountHolder other)
        {
            return other != null && string.Equals(other.EmailAddress, this.EmailAddress, StringComparison.Ordinal);
        }
        #endregion

        #region Object overrided methods

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return obj.GetType() == this.GetType() && this.Equals((AccountHolder)obj);
        }

        public override string ToString() =>
            $"{this.FirstName} {this.SecondName} {this.EmailAddress}" +
            $"{this.Role} {this.Accounts.Count}";

        public override int GetHashCode()
        {
            return $"{FirstName} {SecondName} {EmailAddress}".GetHashCode();
        }

        #endregion

        #region private methods
        private static void VerifyString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{value} is null or white space.");
            }
        }

        private static void VerifyEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
            }
            catch (Exception)
            {
                throw new ArgumentException($"{email} is invalid.");
            }
        }


        #endregion
    }
}
