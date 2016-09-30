using AutoFP.Loja.Crud.Domain.Interface.Services.Veiculo;
using AutoFP.Loja.Crud.Domain.Services.Veiculo;
using SimpleInjector;

namespace AutoFP.Infra.CrossCutting.Ioc.Loja.Modules.Domain
{
    internal static class ServiceModule
    {
        internal static void RegisterServices(Container container)
        {
            // Veículo
            container.Register<IModeloService,ModeloService>(Lifestyle.Scoped);
            container.Register<ICarroService, CarroService>(Lifestyle.Scoped);
        }
    }
}