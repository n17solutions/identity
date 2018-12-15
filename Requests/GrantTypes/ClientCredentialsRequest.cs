using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace N17Solutions.Identity.Requests.GrantTypes
{
    public class ClientCredentialsRequest : IRequest<AuthenticationTicket>
    {
        /// <summary>
        /// The identifier of the Client Application
        /// </summary>
        public string ClientId { get; set; }
    }
}