using System.Web.Http;
using System.Web.Http.Cors;
using AutoFP.Infra.CrossCutting.Ioc.DomainEvent;
using AutoFP.Infra.CrossCutting.Ioc.Gerencia;
using AutoFP.SharedKernel.DomainEvents;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace AutoFP.Gerencia.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            ConfigureCors(config);
            ConfigureWebApi(config);
            ConfigureDependecyInjection(config);

            app.UseWebApi(config);
        }

        private static void ConfigureCors(HttpConfiguration config)
        {
            const string origins = "http://localhost:14127, http://localhost:7000";
            const string headers = "*";
            const string methods = "GET, POST, PUT, DELETE, OPTIONS";
            var cors = new EnableCorsAttribute(origins, headers, methods);
            config.EnableCors(cors);
        }

        private static void ConfigureWebApi(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void ConfigureDependecyInjection(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            GerenciaContainer.DependencyResolver(container);
            DomainEvent.Container = new DomainEventsContainer(container);
            container.Verify(); // TODO: Remover chamada em produção
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}