using BLL.Interfaces.Entities.UserEntities;

namespace BLL.Interfaces.AccountIdServices
{
    public interface IAccountIdGenerator
    {
        string GenerateAccountId(string email);
    }
}
