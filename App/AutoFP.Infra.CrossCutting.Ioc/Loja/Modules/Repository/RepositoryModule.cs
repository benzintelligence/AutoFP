using AutoFP.Loja.Crud.Domain.Interface.Repositories.Veiculo;
using AutoFP.Loja.Crud.Infra.Data.Repositories.Veiculo;
using SimpleInjector;

namespace AutoFP.Infra.CrossCutting.Ioc.Loja.Modules.Repository
{
    internal static class RepositoryModule
    {
        internal static void RegisterRepositories(Container container)
        {
            // Veículo
            container.Register<IModeloRepository, ModeloRepository>(Lifestyle.Scoped);
            container.Register<ICarroRepository, CarroRepository>(Lifestyle.Scoped);
        }
    }
}