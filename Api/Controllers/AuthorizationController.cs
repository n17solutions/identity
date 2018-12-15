using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using N17Solutions.Identity.Library.Exceptions;
using N17Solutions.Identity.Requests.GrantTypes;
using OpenIddict.Mvc.Internal;

namespace N17Solutions.Identity.Api.Controllers
{
    public class AuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("~/connect/token"), Produces("application/json")]
        public async Task<IActionResult> Exchange([ModelBinder(typeof(OpenIddictMvcBinder))]
            OpenIdConnectRequest request)
        {
            try
            {
                if (request.IsClientCredentialsGrantType())
                {
                    // Note: the client credentials are automatically validated by OpenIddict:
                    // if client_id or client_secret are invalid, this action will not be invoked
                    var ticket = await _mediator.Send(new ClientCredentialsRequest {ClientId = request.ClientId}, HttpContext.RequestAborted);
                    return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
                }
            }
            catch (IdentityException ex)
            {
                return BadRequest(ex.Response);
            }

            return BadRequest(new OpenIdConnectResponse
            {
                Error = OpenIdConnectConstants.Errors.UnsupportedGrantType,
                ErrorDescription = "The specified grant type is not supported."
            });
        }
    }
}