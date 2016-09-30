using AutoFP.Loja.Crud.Application.AppService.Veiculo;
using AutoFP.Loja.Crud.Application.Interface.Veiculo;
using SimpleInjector;

namespace AutoFP.Infra.CrossCutting.Ioc.Loja.Modules.Application
{
    internal static class ApplicationServiceModule
    {
        internal static void RegisterAppServices(Container container)
        {
            // Veículo
            container.Register<IModeloApplicationService, ModeloApplicationService>(Lifestyle.Scoped);
            container.Register<ICarroApplicationService, CarroApplicationService>(Lifestyle.Scoped);
        }
    }
}