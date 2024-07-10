using Microsoft.Extensions.DependencyInjection;
using Oqtane.Services;
using ToSic.Module.AnalyzeServiceLifetimes.Shared.Services;

namespace ToSic.Module.AnalyzeServiceLifetimes.Client;

public class ClientStartup: IClientStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        new ServiceScopeStartUp().ConfigureServices(services);
    }
}