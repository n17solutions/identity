using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using N17Solutions.Identity.Data.Contexts;
using N17Solutions.Identity.Library.SeedData;
using OpenIddict.Core;
using OpenIddict.EntityFrameworkCore.Models;

namespace N17Solutions.Identity.Library.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task InitializeOpenIddict(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IdentityContext>();

                if ((await context.Database.GetPendingMigrationsAsync().ConfigureAwait(false)).Any())
                    await context.Database.MigrateAsync().ConfigureAwait(false);

                var identityManager = serviceScope.ServiceProvider.GetRequiredService<OpenIddictApplicationManager<OpenIddictApplication>>();

                foreach (var clientApplication in new ClientApplications())
                {
                    if (await identityManager.FindByClientIdAsync(clientApplication.ClientId).ConfigureAwait(false) == null)
                        await identityManager.CreateAsync(clientApplication).ConfigureAwait(false);
                }
            }
        }
    }
}