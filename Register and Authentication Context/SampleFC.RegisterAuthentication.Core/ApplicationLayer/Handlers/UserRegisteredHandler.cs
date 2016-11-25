using SampleFC.RegisterAuthentication.Core.Domain.Model.Events;
using SampleFC.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace SampleFC.RegisterAuthentication.Core.ApplicationLayer.Handlers
{
    public class UserRegisteredHandler : IHandler<UserRegistered>, INotifiable<UserRegistered>
    {
        private List<UserRegistered> _notifications;

        public UserRegisteredHandler()
        {
            _notifications = new List<UserRegistered>();
        }
        public void Dispose()
        {
            _notifications = new List<UserRegistered>();
        }

        public void Handle(UserRegistered args)
        {
            _notifications.Add(args);
        }

        public bool HasNotifications()
        {
            return _notifications.Count > 0;
        }

        public IEnumerable<UserRegistered> Notify()
        {
            return _notifications;
        }
    }
}
