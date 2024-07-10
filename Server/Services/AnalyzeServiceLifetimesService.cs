using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Security;
using Oqtane.Shared;
using ToSic.Module.AnalyzeServiceLifetimes.Repository;
using ToSic.Module.AnalyzeServiceLifetimes.Shared.Models;
using ToSic.Module.AnalyzeServiceLifetimes.Shared.Services;

namespace ToSic.Module.AnalyzeServiceLifetimes.Services
{
    public class ServerAnalyzeServiceLifetimesService(
        IAnalyzeServiceLifetimesRepository analyzeServiceLifetimesRepository,
        IUserPermissions userPermissions,
        ITenantManager tenantManager,
        ILogManager logger,
        IHttpContextAccessor accessor,
        SingletonService singleton,
        ScopedService scoped,
        TransientService transient)
        : IAnalyzeServiceLifetimesService, ITransientService
    {
        private readonly Alias _alias = tenantManager.GetAlias();

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


        public async Task<List<Models.AnalyzeServiceLifetimes>> GetAnalyzeServiceLifetimessAsync(int moduleId)
        {
            if (userPermissions.IsAuthorized(accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, moduleId, PermissionNames.View))
            {
                return (await analyzeServiceLifetimesRepository.GetAnalyzeServiceLifetimessAsync(moduleId)).ToList();
            }
            else
            {
                logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Get Attempt {ModuleId}", moduleId);
                return null;
            }
        }

        public async Task<Models.AnalyzeServiceLifetimes> GetAnalyzeServiceLifetimesAsync(int analyzeServiceLifetimesId, int moduleId)
        {
            if (userPermissions.IsAuthorized(accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, moduleId, PermissionNames.View))
            {
                return await analyzeServiceLifetimesRepository.GetAnalyzeServiceLifetimesAsync(analyzeServiceLifetimesId);
            }
            else
            {
                logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Get Attempt {AnalyzeServiceLifetimesId} {ModuleId}", analyzeServiceLifetimesId, moduleId);
                return null;
            }
        }

        public async Task<Models.AnalyzeServiceLifetimes> AddAnalyzeServiceLifetimesAsync(Models.AnalyzeServiceLifetimes analyzeServiceLifetimes)
        {
            if (userPermissions.IsAuthorized(accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, analyzeServiceLifetimes.ModuleId, PermissionNames.Edit))
            {
                analyzeServiceLifetimes = await analyzeServiceLifetimesRepository.AddAnalyzeServiceLifetimesAsync(analyzeServiceLifetimes);
                logger.Log(LogLevel.Information, this, LogFunction.Create, "AnalyzeServiceLifetimes Added {AnalyzeServiceLifetimes}", analyzeServiceLifetimes);
            }
            else
            {
                logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Add Attempt {AnalyzeServiceLifetimes}", analyzeServiceLifetimes);
                analyzeServiceLifetimes = null;
            }
            return analyzeServiceLifetimes;
        }

        public async Task<Models.AnalyzeServiceLifetimes> UpdateAnalyzeServiceLifetimesAsync(Models.AnalyzeServiceLifetimes analyzeServiceLifetimes)
        {
            if (userPermissions.IsAuthorized(accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, analyzeServiceLifetimes.ModuleId, PermissionNames.Edit))
            {
                analyzeServiceLifetimes = await analyzeServiceLifetimesRepository.UpdateAnalyzeServiceLifetimesAsync(analyzeServiceLifetimes);
                logger.Log(LogLevel.Information, this, LogFunction.Update, "AnalyzeServiceLifetimes Updated {AnalyzeServiceLifetimes}", analyzeServiceLifetimes);
            }
            else
            {
                logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Update Attempt {AnalyzeServiceLifetimes}", analyzeServiceLifetimes);
                analyzeServiceLifetimes = null;
            }
            return analyzeServiceLifetimes;
        }

        public async Task DeleteAnalyzeServiceLifetimesAsync(int analyzeServiceLifetimesId, int moduleId)
        {
            if (userPermissions.IsAuthorized(accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, moduleId, PermissionNames.Edit))
            {
                await analyzeServiceLifetimesRepository.DeleteAnalyzeServiceLifetimesAsync(analyzeServiceLifetimesId);
                logger.Log(LogLevel.Information, this, LogFunction.Delete, "AnalyzeServiceLifetimes Deleted {AnalyzeServiceLifetimesId}", analyzeServiceLifetimesId);
            }
            else
            {
                logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Delete Attempt {AnalyzeServiceLifetimesId} {ModuleId}", analyzeServiceLifetimesId, moduleId);
            }
        }

    }
}
