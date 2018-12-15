using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N17Solutions.Identity.Data.Contexts;
using N17Solutions.Identity.Library.Extensions;
using N17Solutions.Identity.Requests.Extensions;

namespace N17Solutions.Identity.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
            => _configuration = configuration;
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Ripe for Semaphore
            var environment = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();
            var useJwt = _configuration.GetValue<bool>("OpenIddict:UseJwt");

            services.AddMvc();

            services
                .AddRequests()
                .AddDbContext<IdentityContext>(options =>
                {
                    options.UseNpgsql(_configuration.GetConnectionString("Database"));
                    options.UseOpenIddict();
                })
                .AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                        .UseDbContext<IdentityContext>();
                })
                .AddServer(options =>
                {
                    options.UseMvc();
                    options.EnableTokenEndpoint("/connect/token");
                    options.EnableIntrospectionEndpoint("/token_info");

                    if (_configuration.GetValue<bool>("OpenIddict:AllowClientCredentialsFlow"))
                        options.AllowClientCredentialsFlow();

                    if (useJwt)
                        options.UseJsonWebTokens();

                    if (!environment.IsDevelopment())
                        return;

                    options.DisableHttpsRequirement();
                    options.AddEphemeralSigningKey();
                })
                .AddValidation();

            if (!useJwt) 
                return;
            
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseAuthentication();
            app.UseMvc();
            
            var initializeOpenIddict = app.InitializeOpenIddict().ContinueWith(result => result);
            initializeOpenIddict.Wait();
        }
    }
}