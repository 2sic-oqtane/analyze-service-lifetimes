using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using ToSic.Module.AnalyzeServiceLifetimes.Shared.Models;

namespace ToSic.Module.AnalyzeServiceLifetimes.Services
{
    public class AnalyzeServiceLifetimesService(IHttpClientFactory http, SiteState siteState)
        : ServiceBase(http, siteState), IAnalyzeServiceLifetimesService, IService
    {
        private string apiUrl => CreateApiUrl("AnalyzeServiceLifetimes");

        public async Task<List<ServiceLifetimeStatus>> GetServiceLifetimes(int moduleId)
        {
            return await GetJsonAsync(CreateAuthorizationPolicyUrl($"{apiUrl}", EntityNames.Module, moduleId), Enumerable.Empty<ServiceLifetimeStatus>().ToList());
        }

    }
}
