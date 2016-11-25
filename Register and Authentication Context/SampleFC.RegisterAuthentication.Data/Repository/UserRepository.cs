using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Interfaces;
using System.Linq;
using SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Specs;
using SampleFC.RegisterAuthentication.Data.Context;

namespace SampleFC.RegisterAuthentication.Data.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly UserRegistrationContext _context;

        public UserRepository(UserRegistrationContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.User.Add(user);
        }

        public User FindUserByUserNameAndPassword(string userName, string password)
        {
            return _context.User.FirstOrDefault(user => user.UserName == userName && user.Password == password);
        }

        public bool CheckIfUserAlreadyExist(User user)
        {
            return _context.User.Any(UserSpecs.UserAlreadyExists(user));
        }
    }
}
