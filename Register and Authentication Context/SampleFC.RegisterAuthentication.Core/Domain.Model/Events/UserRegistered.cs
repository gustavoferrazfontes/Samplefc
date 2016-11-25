using System;
using SampleFC.SharedKernel.Events.Interfaces;
using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;

namespace SampleFC.RegisterAuthentication.Core.Domain.Model.Events
{
    public sealed class UserRegistered : IDomainEvent
    {
        private DateTime _dateOccured;
        public DateTime DateOccurred
        {
            get
            {
                return _dateOccured;
            }
        }

        public string Message { get; }

        public string UserName { get; }
        public string Passwaord { get; }

        public UserRegistered(User user)
        {
            Message = $"Usuario registrado! Bem vindo {user.Email}";

            Passwaord = user.Password;

            _dateOccured = DateTime.Now;
        }
    }
}
