using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities.UserEntities;

namespace DAL.Interfaces.DTO
{
    public class DalAccount
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public decimal Balance { get; set; }

        public int BonusPoints { get; set; }

        public AccountHolder AccountHolder { get; set; }
    }
}
