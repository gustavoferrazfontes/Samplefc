using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;
using SampleFC.SharedKernel.Events.Interfaces;
using System;

namespace SampleFC.RegisterAuthentication.Core.Domain.Model.Events
{
    public class UserAuthenticated : IDomainEvent
    {
        private DateTime _dateOccurred;
        public DateTime DateOccurred
        {
            get
            {
                return _dateOccurred;
            }
        }

        public string UserName { get; set; }
        public UserAuthenticated(User user)
        {
            _dateOccurred = DateTime.Now;
            UserName = user.UserName;
        }
    }
}
