using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Oqtane.Infrastructure;
using ToSic.Module.AnalyzeServiceLifetimes.Repository;
using ToSic.Module.AnalyzeServiceLifetimes.Services;
using ToSic.Module.AnalyzeServiceLifetimes.Shared.Services;

namespace ToSic.Module.AnalyzeServiceLifetimes.Startup
{
    public class AnalyzeServiceLifetimesServerStartup : IServerStartup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // not implemented
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            // not implemented
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAnalyzeServiceLifetimesService, ServerAnalyzeServiceLifetimesService>();
            services.AddDbContextFactory<AnalyzeServiceLifetimesContext>(opt => { }, ServiceLifetime.Transient);

            new ServiceScopeStartUp().ConfigureServices(services);
        }
    }
}
