using Moq;
using Moq.Sequences;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Commands;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.UseCases;
using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Interfaces;
using SampleFC.SharedKernel.Events;
using SampleFC.SharedKernel.Interfaces;
using Xunit;

namespace SampleFC.RegisterAuth.Core.Tests.ApplicationLayerTests
{
    public class GivenAnUserRegistration
    {
        public Mock<IEncryptionService> EncriptionService { get; internal set; }
        public Mock<IUserRepository> UserRepository { get; internal set; }
        public Mock<IUnitOfWork> UnitOfWork { get; internal set; }
        public Mock<INotifiable<DomainNotification>> DomainNotification { get; internal set; }
        public UserRegistration UserRegistration { get; internal set; }

        public GivenAnUserRegistration()
        {
            EncriptionService = new Mock<IEncryptionService>();
            UserRepository = new Mock<IUserRepository>();
            UnitOfWork = new Mock<IUnitOfWork>();
            DomainNotification = new Mock<INotifiable<DomainNotification>>();
            UserRegistration = new UserRegistration(EncriptionService.Object, UserRepository.Object, UnitOfWork.Object, DomainNotification.Object);
        }
    }

    public class WhenRegisteringAnUser : IClassFixture<GivenAnUserRegistration>
    {
        private readonly GivenAnUserRegistration _givenAnUserRegistration;
        private RegisterCommand _command;
        public WhenRegisteringAnUser(GivenAnUserRegistration givenAnUserRegistration)
        {
            _givenAnUserRegistration = givenAnUserRegistration;
            _command = new RegisterCommand { Email = "gustavo@gmail.com", EmailConfirmed = "gustavo@gmail.com", UserName = "gustavo", Password = "123456" };
        }

        [Fact]
        public void ThenValidUserIsRegistered()
        {
            using (Sequence.Create())
            {
                _givenAnUserRegistration.EncriptionService.Setup(_ => _.GenereteEncryption(It.IsAny<string>())).InSequence();
                _givenAnUserRegistration.UserRepository.Setup(_ => _.CheckIfUserAlreadyExist(It.IsAny<User>())).InSequence();
                _givenAnUserRegistration.UserRepository.Setup(_ => _.Add(It.IsAny<User>())).InSequence();

                _givenAnUserRegistration.UserRegistration.Register(_command);
            }
        }
    }
}
