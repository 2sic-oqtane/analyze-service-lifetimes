using System.Collections.Generic;
using System.Threading.Tasks;
using ToSic.Module.AnalyzeServiceLifetimes.Shared.Models;

namespace ToSic.Module.AnalyzeServiceLifetimes.Services
{
    public interface IAnalyzeServiceLifetimesService 
    {
        Task<List<ServiceLifetimeStatus>> GetServiceLifetimes(int moduleId);

        //Task<List<Models.AnalyzeServiceLifetimes>> GetAnalyzeServiceLifetimessAsync(int ModuleId);

        //Task<Models.AnalyzeServiceLifetimes> GetAnalyzeServiceLifetimesAsync(int AnalyzeServiceLifetimesId, int ModuleId);

        //Task<Models.AnalyzeServiceLifetimes> AddAnalyzeServiceLifetimesAsync(Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes);

        //Task<Models.AnalyzeServiceLifetimes> UpdateAnalyzeServiceLifetimesAsync(Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes);

        //Task DeleteAnalyzeServiceLifetimesAsync(int AnalyzeServiceLifetimesId, int ModuleId);

    }
}
