using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;
using System;
using System.Linq.Expressions;

namespace SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> UserAlreadyExists(User newUser)
        {
            return user => user.UserName == newUser.UserName;
        }
    }
}
