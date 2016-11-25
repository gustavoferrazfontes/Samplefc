using SampleFC.RegisterAuthentication.Core.Domain.Model.Model.UserAggregate;
using SampleFC.SharedKernel.Validation;

namespace SampleFC.RegisterAuthentication.Core.Domain.Model.UserAggregate.scopes
{
    internal static class UserScopes
    {
        public static bool RegistrationRequire(this User user, bool userExists)
        {
            return AssertionConcern.IsSatisfiedBy
                (

                    AssertionConcern.AssertNotNullOrEmpty(user.UserName, "Necessário informar o usuário de acesso"),
                    AssertionConcern.AssertNotNullOrEmpty(user.Password, "Necessário informar uma senha"),

                    AssertionConcern.AssertNotNullOrEmpty(user.Email, " E-mail é obrigatório"),
                    AssertionConcern.AssertNotNullOrEmpty(user.Email, "A confirmação de e-mail é obrigatória"),
                    AssertionConcern.AssertAreEquals(user.Email, user.EmailConfirmed, "A confirmação é diferente do e-mail informado."),

                    AssertionConcern.AssertFalse(userExists, "nome de usuário já registrado")
                );
        }
    }
}

