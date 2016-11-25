using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;

namespace SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Interfaces
{
    public interface IUserRepository
    {
        bool CheckIfUserAlreadyExist(User user);
        void Add(User user);
        User FindUserByUserNameAndPassword(string userName, string password);
    }
}
