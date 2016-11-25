using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Commands;

namespace SampleFC.RegisterAuthentication.Core.ApplicationLayer.Interfaces
{
    public interface IUserRegistration
    {
        void Register(RegisterCommand command);
    }
}
