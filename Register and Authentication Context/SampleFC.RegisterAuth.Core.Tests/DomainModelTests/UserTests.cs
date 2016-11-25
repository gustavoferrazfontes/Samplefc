using FluentAssertions;
using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Specs;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SampleFC.RegisterAuth.Core.Tests.DomainModelTests
{
    public class GivenUser
    {
        public EncryptionService EncryptionService { get; set; }

        public GivenUser()
        {
            EncryptionService = new EncryptionService();
        }
    }

    public class WhenRegisterAnUser : IClassFixture<GivenUser>
    {
        private GivenUser _givenAnUser;
        User newUser;
        bool userExists;
        string strongPassword;
        List<User> _registeredUsers;
        public WhenRegisterAnUser(GivenUser givenAnUser)
        {
            _givenAnUser = givenAnUser;
            _registeredUsers = new List<User>
            {
                new User("gustavo@gmail.com", "gustavo@gmail.com", "joao.xpto", "123456"),
                new User("gustavo@gmail.com", "gustavo@gmail.com", "xpto", "123456")
            };

            newUser = new User("gustavo@gmail.com", "gustavo@gmail.com", "gustavo", "123456");
            strongPassword = _givenAnUser.EncryptionService.GenereteEncryption(newUser.Password);
            userExists = _registeredUsers.AsQueryable().Any(UserSpecs.UserAlreadyExists(newUser));
        }

        [Fact]
        public void ThenPasswordIsEncrypted()
        {
          
            strongPassword.Should().NotBe(newUser.Password);
        }

        [Fact]
        public void ThenUserNameMustBeUnique()
        {
            
            userExists.Should().Be(false);
        }


        [Fact]
        public void ThenUserMustBeValid()
        {
            newUser.ValidateRegistration(userExists).Should().Be(true);
        }

    }
}
