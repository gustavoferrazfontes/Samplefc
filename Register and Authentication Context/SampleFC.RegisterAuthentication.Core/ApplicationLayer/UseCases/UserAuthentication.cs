using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Interfaces;
using SampleFC.RegisterAuthentication.Core.Domain.Model.Events;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Interfaces;
using SampleFC.SharedKernel.Events;
using SampleFC.SharedKernel.Interfaces;

namespace SampleFC.RegisterAuthentication.Core.ApplicationLayer.Services
{
    public class UserAuthentication : UseCaseBase, IUserAuthentication
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encriptionService;

        public UserAuthentication(IUnitOfWork uow, IUserRepository userRepository, INotifiable<DomainNotification> domainNotification, IEncryptionService encriptionService) :
            base(uow, domainNotification)
        {
            _userRepository = userRepository;
            _encriptionService = encriptionService;
        }


        public void Authenticate(string userName, string password)
        {
            var strongPassword = _encriptionService.GenereteEncryption(password);

            var user = _userRepository.FindUserByUserNameAndPassword(userName, strongPassword);

            if (user != null)
                DomainEvent.Raise(new UserAuthenticated(user));
        }
    }
}
