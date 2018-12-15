using System;
using System.Linq.Expressions;
using N17Solutions.Identity.Responses.ClientApplications;
using N17Solutions.Infrastructure.Domain.Model;

namespace N17Solutions.Identity.Domain.Models.ClientApplications
{
    public class AllowedResource : Entity<long>
    {
        /// <summary>
        /// The identifier of the Client Application
        /// </summary>
        public string ClientId { get; set; }
        
        /// <summary>
        /// The identifier of the Client Application that the given Client Application is allowed access to
        /// </summary>
        public string AllowedResourceClientId { get; set; }

        /// <summary>
        /// Maps a <see cref="AllowedResource" /> domain model to a <see cref="AllowedResourceResponse" /> object.
        /// </summary>
        /// <remarks>Executes an expression tree, useful for using in EntityFramework type query scenarios</remarks>
        public static Expression<Func<AllowedResource, AllowedResourceResponse>> ToAllowedResourceResponse =>
            domainModel =>
                new AllowedResourceResponse
                {
                    AllowedResourceClientId = domainModel.AllowedResourceClientId
                };
    }
}