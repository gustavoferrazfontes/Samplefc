using SampleFC.SharedKernel.Events;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SampleFC.SharedKernel.Validation
{
    public static class AssertionConcern
    {
        public static bool IsSatisfiedBy(params DomainNotification[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            NotifyAll(notificationsNotNull);

            return notificationsNotNull.Count().Equals(0);
        }

        private static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(validation =>
            {
                DomainEvent.Raise<DomainNotification>(validation);
            });
        }

        public static DomainNotification AssertLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;

            return (length < minimum || length > maximum) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertMatches(string pattern, string stringValue, string message)
        {
            var regex = new Regex(pattern);

            return (!regex.IsMatch(stringValue)) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertNotNullOrEmpty(string stringValue, string message)
        {
            return (string.IsNullOrEmpty(stringValue)) ?
                new DomainNotification("AssertNotNullOrEmpty", message) : null;
        }

        public static DomainNotification AssertNotNull(object object1, string message)
        {

            return (object1 == null) ?
                new DomainNotification("AssertArgumentNotNull", message) : null;
        }

        public static DomainNotification AssertTrue(bool boolValue, string message)
        {
            return (!boolValue) ?
                new DomainNotification("AssertTrue", message) : null;
        }

        public static DomainNotification AssertFalse(bool boolValue, string message)
        {
            return (!boolValue) ?
               null : new DomainNotification("AssertFalse", message);
        }

        public static DomainNotification AssertAreEquals(string value, string match, string message)
        {
            return (!(value == match)) ?
                new DomainNotification("AssertAreEquals", message) : null;
        }

        public static DomainNotification AssertAreNotEquals(string value, string match, string message)
        {
            return (value == match) ?
                new DomainNotification("AssertAreNotEquals", message) : null;
        }

        public static DomainNotification AssertIsGreaterThan(int value1, int value2, string message)
        {
            return (!(value1 > value2)) ?
                new DomainNotification("AssertIsGreaterThan", message) : null;
        }

        public static DomainNotification AssertIsGreaterThan(decimal value1, decimal value2, string message)
        {
            return (!(value1 > value2)) ?
                new DomainNotification("AssertIsGreaterThan", message) : null;
        }

        public static DomainNotification AssertIsGreaterOrEqualThan(int value1, int value2, string message)
        {
            return (!(value1 >= value2)) ?
                new DomainNotification("AssertIsGreaterOrEqualThan", message) : null;
        }
    }
}
