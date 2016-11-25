using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Commands;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Interfaces;
using SampleFC.RegisterAuthentication.Core.Domain.Model.Events;
using SampleFC.SharedKernel.Events;
using SampleFC.SharedKernel.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleApi.Controllers
{
    public class RegisterAndAuthenticationController : BaseApiController
    {
        private readonly IUserRegistration _userRegistration;
        private readonly INotifiable<UserRegistered> _userNotification;
        private readonly INotifiable<DomainNotification> _domainNotification;

        public RegisterAndAuthenticationController(IUserRegistration userRegistration, INotifiable<DomainNotification> domainNotification, INotifiable<UserRegistered> userNotification)
        {
            _userRegistration = userRegistration;
            _domainNotification = domainNotification;
            _userNotification = userNotification;
        }

        [HttpPost]
        [Route("api/users")]
        public Task<HttpResponseMessage> Post([FromBody]RegisterCommand command)
        {

            _userRegistration.Register(command);

            return Notifiy(_domainNotification, _userNotification);
        }
    }
}
