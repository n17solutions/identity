using System.Collections.Generic;
using MediatR;
using N17Solutions.Identity.Responses.ClientApplications;

namespace N17Solutions.Identity.Requests.ClientApplications
{
    public class GetAllowedResourcesRequest : IRequest<IEnumerable<AllowedResourceResponse>>
    {
        /// <summary>
        /// The identifier of the Client Application of who's allowed resources we are retrieving
        /// </summary>
        public string ClientId { get; set; }
    }
}