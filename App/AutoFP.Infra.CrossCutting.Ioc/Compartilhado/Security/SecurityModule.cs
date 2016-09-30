using AutoFP.Infra.CrossCutting.Security.Interfaces.Services;
using AutoFP.Infra.CrossCutting.Security.Services;
using SimpleInjector;

namespace AutoFP.Infra.CrossCutting.Ioc.Compartilhado.Security
{
    internal static class SecurityModule
    {
        internal static void RegisterSecurity(Container container)
        {
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
        }
    }
}