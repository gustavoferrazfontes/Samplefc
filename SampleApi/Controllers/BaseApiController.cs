using SampleFC.SharedKernel.Events;
using SampleFC.SharedKernel.Events.Interfaces;
using SampleFC.SharedKernel.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleApi.Controllers
{
    public class BaseApiController : ApiController
    {

        public Task<HttpResponseMessage> Notifiy<T>(INotifiable<DomainNotification> domainNotification, INotifiable<T> otherNotification) where T : IDomainEvent
        {
            if (domainNotification.HasNotifications())
            {
                return Task.FromResult(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, domainNotification.Notify()));
            }
            else if (otherNotification.HasNotifications())
            {
                return Task.FromResult(Request.CreateResponse(System.Net.HttpStatusCode.OK, otherNotification.Notify()));
            }

            return null;

        }
    }
}
