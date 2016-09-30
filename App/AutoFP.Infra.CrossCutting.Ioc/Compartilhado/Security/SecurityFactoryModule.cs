using AutoFP.Infra.CrossCutting.Security.Factories;
using AutoFP.Infra.CrossCutting.Security.Interfaces.Factories;
using SimpleInjector;

namespace AutoFP.Infra.CrossCutting.Ioc.Compartilhado.Security
{
    internal static class SecurityFactoryModule
    {
        internal static void RegisterSecurityFactories(Container container)
        {
            container.Register<IUserFactory, UserFactory>(Lifestyle.Singleton);
        }
    }
}