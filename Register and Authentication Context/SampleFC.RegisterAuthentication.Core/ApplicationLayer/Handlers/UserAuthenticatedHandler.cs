using SampleFC.RegisterAuthentication.Core.Domain.Model.Events;
using SampleFC.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace SampleFC.RegisterAuthentication.Core.ApplicationLayer.Handlers
{
    public class UserAuthenticatedHandler : IHandler<UserAuthenticated>, INotifiable<UserAuthenticated>
    {
        private List<UserAuthenticated> notification;
        public void Dispose()
        {
            notification = new List<UserAuthenticated>();
        }
        public UserAuthenticatedHandler()
        {
            notification = new List<UserAuthenticated>();
        }

        public void Handle(UserAuthenticated args)
        {
            notification.Add(args);
        }

        public bool HasNotifications()
        {
            return notification.Count > 0;
        }

        public IEnumerable<UserAuthenticated> Notify()
        {
            return notification;
        }
    }
}
