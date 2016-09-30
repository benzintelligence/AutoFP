using System;
using System.Collections.Generic;
using AutoFP.SharedKernel.DomainEvents.Events;

namespace AutoFP.SharedKernel.DomainEvents.Handles
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);

        bool HasNotifications();

        IEnumerable<T> Notify();
    }
}