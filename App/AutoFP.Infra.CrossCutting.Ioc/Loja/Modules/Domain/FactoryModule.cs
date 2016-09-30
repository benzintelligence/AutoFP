using AutoFP.Loja.Crud.Domain.Factories.Veiculo;
using AutoFP.Loja.Crud.Domain.Interface.Factories.Veiculo;
using SimpleInjector;

namespace AutoFP.Infra.CrossCutting.Ioc.Loja.Modules.Domain
{
    internal static class FactoryModule
    {
        internal static void RegisterFactories(Container container)
        {
            // Veículo
            container.Register<ICarroFactory, CarroFactory>(Lifestyle.Singleton);
            container.Register<IModeloFactory, ModeloFactory>(Lifestyle.Singleton);
        }
    }
}