using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;

namespace SampleFC.RegisterAuthentication.Core.ApplicationLayer.Interfaces
{
    public interface IUserApplicationService
    {
        User Authenticate(string userName, string password);
    }
}
