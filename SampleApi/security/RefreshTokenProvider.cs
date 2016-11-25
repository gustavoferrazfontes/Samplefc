using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Collections.Concurrent;
using System.Net;

namespace NotasFaltas.WebApi.security
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        private static ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();
        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();
            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                IssuedUtc = context.Ticket.Properties.IssuedUtc,
                ExpiresUtc = DateTime.UtcNow.AddSeconds(5)
            };
            var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);
            _refreshTokens.TryAdd(guid, refreshTokenTicket);
            context.SetToken(guid);
            return Task.FromResult<object>(refreshTokenTicket);
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            AuthenticationTicket ticket;
            var header = context.OwinContext.Request.Headers["Authorization"];
            if (_refreshTokens.TryRemove(context.Token, out ticket))
                context.SetTicket(ticket);

        
            return Task.FromResult<object>(context.Response.Headers);
        }
    }
}