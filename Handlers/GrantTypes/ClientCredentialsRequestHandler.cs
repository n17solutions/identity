using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using N17Solutions.Identity.Library.Exceptions;
using N17Solutions.Identity.Requests.GrantTypes;
using OpenIddict.Core;
using OpenIddict.EntityFrameworkCore.Models;
using OpenIddict.Server;

namespace N17Solutions.Identity.Handlers.GrantTypes
{
    public class ClientCredentialsRequestHandler : IRequestHandler<ClientCredentialsRequest, AuthenticationTicket>
    {
        private readonly OpenIddictApplicationManager<OpenIddictApplication> _applicationManager;

        public ClientCredentialsRequestHandler(OpenIddictApplicationManager<OpenIddictApplication> applicationManager)
        {
            _applicationManager = applicationManager;
        }

        public async Task<AuthenticationTicket> Handle(ClientCredentialsRequest request, CancellationToken cancellationToken)
        {
            var application = await _applicationManager.FindByClientIdAsync(request.ClientId, cancellationToken).ConfigureAwait(false);

            if (application == null)
                throw new InvalidClientApplicationException(request.ClientId);

            return CreateTicket(application);
        }

        private AuthenticationTicket CreateTicket(OpenIddictApplication application)
        {
            var identity = new ClaimsIdentity(
                OpenIddictServerDefaults.AuthenticationScheme,
                OpenIdConnectConstants.Claims.Name,
                OpenIdConnectConstants.Claims.Role
            );

            identity.AddClaim(
                OpenIdConnectConstants.Claims.Subject,
                application.ClientId,
                OpenIdConnectConstants.Destinations.AccessToken,
                OpenIdConnectConstants.Destinations.IdentityToken);
            
            identity.AddClaim(
                OpenIdConnectConstants.Claims.Name,
                application.DisplayName,
                OpenIdConnectConstants.Destinations.AccessToken,
                OpenIdConnectConstants.Destinations.IdentityToken);
            
            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                new AuthenticationProperties(),
                OpenIddictServerDefaults.AuthenticationScheme);

            return ticket;
        }
    }
}