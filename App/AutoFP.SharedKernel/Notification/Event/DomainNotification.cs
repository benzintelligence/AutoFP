using System;
using AutoFP.SharedKernel.DomainEvents.Events;

namespace AutoFP.SharedKernel.Notification.Event
{
    public class DomainNotification : IDomainEvent
    {
        public string Key { get; }

        public string Value { get; }

        public DateTime Date { get; }

        public DomainNotification(string key, string value)
        {
            this.Key = key;
            this.Value = value;
            this.Date = DateTime.Now;
        }
    }
}