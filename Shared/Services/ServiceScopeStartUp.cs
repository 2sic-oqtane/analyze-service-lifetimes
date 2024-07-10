using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ToSic.Module.AnalyzeServiceLifetimes.Shared.Services;

public class ServiceScopeStartUp 
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.TryAddTransient<TransientService>();
        services.TryAddScoped<ScopedService>();
        services.TryAddSingleton<SingletonService>();
    }
}