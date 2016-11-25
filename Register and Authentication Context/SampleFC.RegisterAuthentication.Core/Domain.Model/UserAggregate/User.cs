using System;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.scopes;

namespace SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate
{
    public sealed class User : Entity
    {

        public string Email { get; private set; }
        public string EmailConfirmed { get; private set; }

        public string UserName { get; private set; }
        public string Password { get; private set; }

        public User(string email, string emailConfirmed, string userName, string password)
        {

            Email = email;
            EmailConfirmed = emailConfirmed;
            UserName = userName;
            Password = password;
        }


        public bool ValidateRegistration(bool userExists)
        {
            return this.RegistrationRequire(userExists);
        }


    }
}
