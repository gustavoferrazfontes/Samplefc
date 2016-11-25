using Microsoft.Owin.Security.OAuth;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Interfaces;
using SampleFC.RegisterAuthentication.Core.Domain.Model.Events;
using SampleFC.SharedKernel.Events;
using SampleFC.SharedKernel.Interfaces;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace NotasFaltas.WebApi.security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserAuthentication _userAuthentication;
        private readonly INotifiable<UserAuthenticated> _userAuthenticateNotification;
        public SimpleAuthorizationServerProvider(IUserAuthentication userAuthentication,INotifiable<UserAuthenticated> userAuthenticateNotification)
        {

            _userAuthentication = userAuthentication;
            _userAuthenticateNotification = userAuthenticateNotification;
        }


        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            _userAuthentication.Authenticate(context.UserName, context.Password);

            if (!_userAuthenticateNotification.HasNotifications())
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos!");
                return;
            }
            var user = _userAuthenticateNotification.Notify().First();


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            var principal = new GenericPrincipal(identity, new string[] { user.UserName });
            Thread.CurrentPrincipal = principal;

            context.Validated(identity);
        }
    }
}