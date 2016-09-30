using AutoFP.Infra.CrossCutting.Ioc.Compartilhado.Security;
using AutoFP.Infra.CrossCutting.Ioc.Loja.Modules.Application;
using AutoFP.Infra.CrossCutting.Ioc.Loja.Modules.Domain;
using AutoFP.Infra.CrossCutting.Ioc.Loja.Modules.Repository;
using SimpleInjector;

namespace AutoFP.Infra.CrossCutting.Ioc.Loja
{
    public static class LojaContainer
    {
        public static void DependencyResolver(Container container)
        {
            // Application
            ApplicationServiceModule.RegisterAppServices(container);

            // Domain
            DomainEventsModule.RegisterDomainEvents(container);
            FactoryModule.RegisterFactories(container);
            ServiceModule.RegisterServices(container);

            // Repository
            DataAccessModule.RegisterDataAccess(container);
            RepositoryModule.RegisterRepositories(container);

            // Security
            SecurityFactoryModule.RegisterSecurityFactories(container);
            SecurityModule.RegisterSecurity(container);
            SecurityRepository.RegisterSecurityRepository(container);
        }
    }
}