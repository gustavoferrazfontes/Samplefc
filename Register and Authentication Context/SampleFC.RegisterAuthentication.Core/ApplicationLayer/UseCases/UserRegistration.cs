using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Commands;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Interfaces;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Services;
using SampleFC.RegisterAuthentication.Core.Domain.Model.Events;
using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Interfaces;
using SampleFC.SharedKernel.Events;
using SampleFC.SharedKernel.Interfaces;

namespace SampleFC.RegisterAuthentication.Core.ApplicationLayer.UseCases
{
    public class UserRegistration : UseCaseBase, IUserRegistration
    {

        private readonly IEncryptionService _encryptionService;
        private readonly IUserRepository _userRepository;

        public UserRegistration(IEncryptionService encryptionService, IUserRepository userRepository, IUnitOfWork uow, INotifiable<DomainNotification> domainNotification)
            : base(uow, domainNotification)
        {
            _encryptionService = encryptionService;
            _userRepository = userRepository;

        }
        public void Register(RegisterCommand command)
        {
            var strongPassword = _encryptionService.GenereteEncryption(command.Password);
            var newUser = new User(command.Email, command.EmailConfirmed, command.UserName, strongPassword);
            var exists = _userRepository.CheckIfUserAlreadyExist(newUser);

            _userRepository.Add(newUser);

            newUser.ValidateRegistration(exists);
            if (Commit())
                DomainEvent.Raise(new UserRegistered(newUser));



        }
    }
}
