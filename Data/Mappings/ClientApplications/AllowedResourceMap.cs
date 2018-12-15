using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N17Solutions.Identity.Domain.Models.ClientApplications;

namespace N17Solutions.Identity.Data.Mappings.ClientApplications
{
    public class AllowedResourceMap : IEntityTypeConfiguration<AllowedResource>
    {
        public void Configure(EntityTypeBuilder<AllowedResource> builder)
        {
            builder.HasIndex(p => p.ClientId);
        }
    }
}