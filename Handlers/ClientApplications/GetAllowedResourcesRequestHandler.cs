using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using N17Solutions.Identity.Data.Contexts;
using N17Solutions.Identity.Domain.Models.ClientApplications;
using N17Solutions.Identity.Requests.ClientApplications;
using N17Solutions.Identity.Responses.ClientApplications;

namespace N17Solutions.Identity.Handlers.ClientApplications
{
    public class GetAllowedResourcesRequestHandler : IRequestHandler<GetAllowedResourcesRequest, IEnumerable<AllowedResourceResponse>>
    {
        private readonly IdentityContext _context;

        public GetAllowedResourcesRequestHandler(IdentityContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllowedResourceResponse>> Handle(GetAllowedResourcesRequest request, CancellationToken cancellationToken)
        {
            var allowedResources = await _context.ClientApplicationAllowedResources
                .Where(ar => ar.ClientId == request.ClientId)
                .Select(AllowedResource.ToAllowedResourceResponse)
                .ToArrayAsync(cancellationToken).ConfigureAwait(false);

            return allowedResources;
        }
    }
}