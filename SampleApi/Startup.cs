using IoC;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using NotasFaltas.WebApi.security;
using Owin;
using SampleFC.RegisterAuthentication.Core.ApplicationLayer.Interfaces;
using SampleFC.RegisterAuthentication.Core.Domain.Model.Events;
using SampleFC.SharedKernel.Events;
using SampleFC.SharedKernel.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(SampleApi.Startup))]
namespace SampleApi
{

    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            configureDependencyInjection(config, container);

            ConfigureOAuth(app, container.GetInstance<IUserAuthentication>(),
                container.GetInstance<INotifiable<UserAuthenticated>>());

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private static void configureDependencyInjection(HttpConfiguration config, Container container)
        {
            Bootstrapper.Initialize(container);
            container.RegisterWebApiControllers(config);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            DomainEvent.Container = new DomainEventsContainer(new SimpleInjectorWebApiDependencyResolver(container));
        }

        private static void ConfigureOAuth(IAppBuilder app, IUserAuthentication userAppService, INotifiable<UserAuthenticated> userAuthenticateNotification)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1),
                ApplicationCanDisplayErrors = true,
                Provider = new SimpleAuthorizationServerProvider(userAppService, userAuthenticateNotification)


            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}