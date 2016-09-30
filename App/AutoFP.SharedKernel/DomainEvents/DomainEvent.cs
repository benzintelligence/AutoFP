using AutoFP.SharedKernel.DomainEvents.Container;
using AutoFP.SharedKernel.DomainEvents.Events;
using AutoFP.SharedKernel.DomainEvents.Handles;

namespace AutoFP.SharedKernel.DomainEvents
{
    public static class DomainEvent
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T evento) where T : IDomainEvent
        {
            ((IHandler<T>) Container.GetService( typeof(IHandler<T>))).Handle(evento);
        }
    }
}