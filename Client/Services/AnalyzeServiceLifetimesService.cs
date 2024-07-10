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
        private string Apiurl => CreateApiUrl("AnalyzeServiceLifetimes");

        public async Task<List<ServiceLifetimeStatus>> GetServiceLifetimes(int moduleId)
        {
            return await GetJsonAsync(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, moduleId), Enumerable.Empty<ServiceLifetimeStatus>().ToList());
        }

        public async Task<List<Models.AnalyzeServiceLifetimes>> GetAnalyzeServiceLifetimessAsync(int moduleId)
        {
            var analyzeServiceLifetimess = await GetJsonAsync(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={moduleId}", EntityNames.Module, moduleId), Enumerable.Empty<Models.AnalyzeServiceLifetimes>().ToList());
            return analyzeServiceLifetimess.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.AnalyzeServiceLifetimes> GetAnalyzeServiceLifetimesAsync(int analyzeServiceLifetimesId, int moduleId)
        {
            return await GetJsonAsync<Models.AnalyzeServiceLifetimes>(CreateAuthorizationPolicyUrl($"{Apiurl}/{analyzeServiceLifetimesId}", EntityNames.Module, moduleId));
        }

        public async Task<Models.AnalyzeServiceLifetimes> AddAnalyzeServiceLifetimesAsync(Models.AnalyzeServiceLifetimes analyzeServiceLifetimes)
        {
            return await PostJsonAsync(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, analyzeServiceLifetimes.ModuleId), analyzeServiceLifetimes);
        }

        public async Task<Models.AnalyzeServiceLifetimes> UpdateAnalyzeServiceLifetimesAsync(Models.AnalyzeServiceLifetimes analyzeServiceLifetimes)
        {
            return await PutJsonAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{analyzeServiceLifetimes.AnalyzeServiceLifetimesId}", EntityNames.Module, analyzeServiceLifetimes.ModuleId), analyzeServiceLifetimes);
        }

        public async Task DeleteAnalyzeServiceLifetimesAsync(int analyzeServiceLifetimesId, int moduleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{analyzeServiceLifetimesId}", EntityNames.Module, moduleId));
        }

    }
}
