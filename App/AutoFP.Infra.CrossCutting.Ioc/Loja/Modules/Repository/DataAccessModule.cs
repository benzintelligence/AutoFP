using AutoFP.Infra.Data.Connection.App;
using AutoFP.Infra.Data.Interface;
using SimpleInjector;

namespace AutoFP.Infra.CrossCutting.Ioc.Loja.Modules.Repository
{
    internal static class DataAccessModule
    {
        internal static void RegisterDataAccess(Container container)
        {
            container.Register<IAppDatabase, SqlServerAppConnection>(Lifestyle.Scoped);
        }
    }
}