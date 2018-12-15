using Microsoft.EntityFrameworkCore;
using N17Solutions.Infrastructure.Data.EntityFramework.Contexts;

namespace N17Solutions.Identity.Data.Contexts
{
    public class IdentityContext : N17Context
    {
        public IdentityContext(DbContextOptions options) : base(options, typeof(IdentityContext).Assembly)
        {
        }
    }
}