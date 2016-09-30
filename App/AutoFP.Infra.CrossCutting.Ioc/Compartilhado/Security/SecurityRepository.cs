using AutoFP.Infra.CrossCutting.Security.Interfaces.Repositories;
using AutoFP.Infra.Data.Repositories.Security;
using SimpleInjector;

namespace AutoFP.Infra.CrossCutting.Ioc.Compartilhado.Security
{
    internal static class SecurityRepository
    {
        internal static void RegisterSecurityRepository(Container container)
        {
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
        }
    }
}