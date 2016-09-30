using AutoFP.SharedKernel.DomainEvents.Handles;
using AutoFP.SharedKernel.Notification.Event;
using AutoFP.SharedKernel.Notification.Handler;
using SimpleInjector;

namespace AutoFP.Infra.CrossCutting.Ioc.Loja.Modules.Domain
{
    internal static class DomainEventsModule
    {
        internal static void RegisterDomainEvents(Container container)
        {
            container.Register<IHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
        }
    }
}