using System.Collections.Generic;
using System.Threading.Tasks;
using Oqtane.Infrastructure;
using Oqtane.Modules;
using ToSic.Module.AnalyzeServiceLifetimes.Shared.Models;
using ToSic.Module.AnalyzeServiceLifetimes.Shared.Services;

namespace ToSic.Module.AnalyzeServiceLifetimes.Services
{
    public class ServerAnalyzeServiceLifetimesService(
        ITenantManager tenantManager,
        SingletonService singleton,
        ScopedService scoped,
        TransientService transient)
        : IAnalyzeServiceLifetimesService, ITransientService
    {
        /// <summary>
        /// Inform the module about the current state of the services on the server.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ServiceLifetimeStatus>> GetServiceLifetimes(int moduleId)
        {
            List<ServiceLifetimeStatus> list =
            [
                singleton.GetStatus("Server"),
                scoped.GetStatus("Server"),
                transient.GetStatus("Server")
            ];
            return list;
        }

    }
}
