using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToSic.Module.AnalyzeServiceLifetimes.Repository
{
    public interface IAnalyzeServiceLifetimesRepository
    {
        IEnumerable<Models.AnalyzeServiceLifetimes> GetAnalyzeServiceLifetimess(int ModuleId);
        Models.AnalyzeServiceLifetimes GetAnalyzeServiceLifetimes(int AnalyzeServiceLifetimesId);
        Models.AnalyzeServiceLifetimes GetAnalyzeServiceLifetimes(int AnalyzeServiceLifetimesId, bool tracking);
        Models.AnalyzeServiceLifetimes AddAnalyzeServiceLifetimes(Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes);
        Models.AnalyzeServiceLifetimes UpdateAnalyzeServiceLifetimes(Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes);
        void DeleteAnalyzeServiceLifetimes(int AnalyzeServiceLifetimesId);

        Task<IEnumerable<Models.AnalyzeServiceLifetimes>> GetAnalyzeServiceLifetimessAsync(int ModuleId);
        Task<Models.AnalyzeServiceLifetimes> GetAnalyzeServiceLifetimesAsync(int AnalyzeServiceLifetimesId);
        Task<Models.AnalyzeServiceLifetimes> GetAnalyzeServiceLifetimesAsync(int AnalyzeServiceLifetimesId, bool tracking);
        Task<Models.AnalyzeServiceLifetimes> AddAnalyzeServiceLifetimesAsync(Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes);
        Task<Models.AnalyzeServiceLifetimes> UpdateAnalyzeServiceLifetimesAsync(Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes);
        Task DeleteAnalyzeServiceLifetimesAsync(int AnalyzeServiceLifetimesId);
    }
}
