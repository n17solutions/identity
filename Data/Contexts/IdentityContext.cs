using Microsoft.EntityFrameworkCore;
using N17Solutions.Identity.Domain.Models.ClientApplications;
using N17Solutions.Infrastructure.Data.EntityFramework.Contexts;

namespace N17Solutions.Identity.Data.Contexts
{
    public class IdentityContext : N17Context
    {
        #region Entities
        public DbSet<AllowedResource> ClientApplicationAllowedResources { get; set; }
        #endregion
        
        public IdentityContext(DbContextOptions options) : base(options, typeof(IdentityContext).Assembly)
        {
        }
    }
}