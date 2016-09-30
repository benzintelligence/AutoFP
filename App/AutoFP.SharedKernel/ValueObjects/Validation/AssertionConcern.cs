using System.Collections.Generic;
using System.Linq;
using AutoFP.SharedKernel.DomainEvents;
using AutoFP.SharedKernel.Notification.Event;

namespace AutoFP.SharedKernel.ValueObjects.Validation
{
    public class AssertionConcern
    {
        public static DomainNotification AssertArgumentGreater(decimal valueReference, decimal valueCompare, string message)
        {
            return (valueReference > valueCompare)
                ? null
                : new DomainNotification("AssertGreaterValue", message);
        }

        public static DomainNotification AssertArgumentRangeNumeric(int value, int min, int max, string message)
        {
            if (value >= min && value <= max)
                return null;

            return new DomainNotification("AssertRangeNumeric", message);
        }

        public static DomainNotification AssertArgumentEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
                return null;

            return new DomainNotification("AssertEquals", message);
        }

        public static DomainNotification AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return null;

            return new DomainNotification("AssertNotEmpty", message);
        }

        public static DomainNotification AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            var notification = AssertArgumentNotEmpty(stringValue, message);
            if (notification != null)
                return notification;

            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
                return new DomainNotification("AssertLenght", message);

            return null;
        }

        public static DomainNotification AssertArgumentNotNull(object objValue, string message)
        {
            if (objValue != null)
                return null;

            return new DomainNotification("AssertNotNull", message);
        }

        public static DomainNotification AssertArgumentNull(object objValue, string message)
        {
            if (objValue == null)
                return null;

            return new DomainNotification("AssertNull", message);
        }

        public static bool IsSatisfiedBy(params DomainNotification[] validations)
        {
            IEnumerable<DomainNotification> notifications = from validation in validations
                                                            where validation != null
                                                            select validation;

            NotifyAll(notifications);
            return notifications.Count<DomainNotification>().Equals(0);
        }

        private static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList<DomainNotification>()
                .ForEach(validation => DomainEvent.Raise<DomainNotification>(validation));
        }
    }
}