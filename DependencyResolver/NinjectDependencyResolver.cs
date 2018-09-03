using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.AccountIdServices;
using BLL.Interfaces.AccountServices;
using BLL.Services;
using DAL;
using BLL;
using DAL.Interfaces;
using Ninject;
using ORM;

namespace DependencyResolver
{
    public static class NinjectDependencyResolver
    {
        public static void Configure(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            kernel.Bind<DbContext>().To<BankSystemContext>().InSingletonScope();

            var dbContext = kernel.Get<DbContext>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>()
                .InSingletonScope()
                .WithConstructorArgument("dbContext", dbContext);

            kernel.Bind<IAccountIdGenerator>().To<AccountIdService>().InSingletonScope();

            var unitOfWork = kernel.Get<IUnitOfWork>();
            var accountRepository = kernel.Get<IAccountRepository>();
            kernel.Bind<IAccountService>().To<AccountService>().InSingletonScope()
                .WithConstructorArgument("unitOfWork", unitOfWork)
                .WithConstructorArgument("accountRepository", accountRepository);
        }
    }
}
