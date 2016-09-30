using System.Text.RegularExpressions;
using AutoFP.SharedKernel.Notification.Event;

namespace AutoFP.SharedKernel.ValueObjects.Validation
{
    public static class EmailAssertionConcern
    {
        public static DomainNotification AssertIsValid(string email, string message)
        {
            return AssertIsValid(email)
                ? null
                : new DomainNotification("AssertEmailIsInvalid", message);
        }

        public static bool AssertIsValid(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}