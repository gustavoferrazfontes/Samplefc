using Moq;
using Moq.Sequences;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Interfaces;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Services;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Interfaces;
using SampleFC.SharedKernel.Events;
using SampleFC.SharedKernel.Interfaces;
using Xunit;

namespace SampleFC.RegisterAuth.Core.Tests.ApplicationLayerTests
{
    public class GivenAnUserAuthentication
    {
        public Mock<IEncryptionService> EncriptionService { get; internal set; }
        public Mock<IUserRepository> UserRepository { get; internal set; }
        public Mock<IUnitOfWork> UnitOfWork { get; internal set; }
        public Mock<INotifiable<DomainNotification>> DomainNotification { get; internal set; }
        public IUserAuthentication UserAuthentication { get; internal set; }
        public GivenAnUserAuthentication()
        {
            UserRepository = new Mock<IUserRepository>();
            UnitOfWork = new Mock<IUnitOfWork>();
            EncriptionService = new Mock<IEncryptionService>();
            DomainNotification = new Mock<INotifiable<DomainNotification>>();
            UserAuthentication = new UserAuthentication(UnitOfWork.Object, UserRepository.Object, DomainNotification.Object, EncriptionService.Object);
        }
    }

    public class WhenAuthenticateAnUser : IClassFixture<GivenAnUserAuthentication>
    {
        private readonly GivenAnUserAuthentication _givenAnUserAuthentication;
        public WhenAuthenticateAnUser(GivenAnUserAuthentication givenAnUserAuthentication)
        {
            _givenAnUserAuthentication = givenAnUserAuthentication;
            
        }

        [Fact]
        public void ThenAValidUserIsAuthenticated()
        {
            using (Sequence.Create())
            {
                _givenAnUserAuthentication.EncriptionService.Setup(_ => _.GenereteEncryption(It.IsAny<string>())).InSequence();
                _givenAnUserAuthentication.UserRepository.Setup(_ => _.FindUserByUserNameAndPassword(It.IsAny<string>(), It.IsAny<string>())).InSequence();

                _givenAnUserAuthentication.UserAuthentication.Authenticate("gustavo.fontes","123456");
            }
        }
    }
}
