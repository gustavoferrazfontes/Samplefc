using SampleFC.CrossCutting.Events;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Handlers;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Interfaces;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Services;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.UseCases;
using SampleFC.RegisterAuthentication.Core.Domain.Model.Events;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Interfaces;
using SampleFC.RegisterAuthentication.Data.Config;
using SampleFC.RegisterAuthentication.Data.Context;
using SampleFC.RegisterAuthentication.Data.Repository;
using SampleFC.SharedKernel.Events;
using SampleFC.SharedKernel.Interfaces;
using SimpleInjector;


namespace IoC
{
    public class Bootstrapper
    {

        public static void Initialize(Container container)
        {

            container.RegisterPerWebRequest<UserRegistrationContext>();
            container.RegisterPerWebRequest<IUserRepository, UserRepository>();
            container.RegisterPerWebRequest<IUnitOfWork, UserRegistrationUnitOfWork>();

            container.Register<IEncryptionService, EncryptionService>();

            container.Register<IUserAuthentication, UserAuthentication>();
            container.Register<IUserRegistration, UserRegistration>();


            var domainHandler = Lifestyle.Singleton.CreateRegistration<DomainNotificationHandler>(container);
            var userRegisteredHadler = Lifestyle.Singleton.CreateRegistration<UserRegisteredHandler>(container);
            var userAuthenticatedHandler = Lifestyle.Singleton.CreateRegistration<UserAuthenticatedHandler>(container);

            container.AddRegistration(typeof(IHandler<DomainNotification>), domainHandler);
            container.AddRegistration(typeof(INotifiable<DomainNotification>), domainHandler);
            container.AddRegistration(typeof(IHandler<UserRegistered>), userRegisteredHadler);
            container.AddRegistration(typeof(INotifiable<UserRegistered>), userRegisteredHadler);
            container.AddRegistration(typeof(IHandler<UserAuthenticated>), userAuthenticatedHandler);
            container.AddRegistration(typeof(INotifiable<UserAuthenticated>), userAuthenticatedHandler);
        }
    }
}
