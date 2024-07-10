using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Infrastructure;
using Oqtane.Controllers;

namespace ToSic.Module.AnalyzeServiceLifetimes.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class AnalyzeServiceLifetimesController(
        ILogManager logger,
        IHttpContextAccessor accessor)
        : ModuleControllerBase(logger, accessor)
    {
        //// GET: api/<controller>?moduleid=x
        //[HttpGet]
        //[Authorize(Policy = PolicyNames.ViewModule)]
        //public IEnumerable<Models.AnalyzeServiceLifetimes> Get(string moduleid)
        //{
        //    int ModuleId;
        //    if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
        //        return analyzeServiceLifetimesRepository.GetAnalyzeServiceLifetimess(ModuleId);
            
        //    _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Get Attempt {ModuleId}", moduleid);
        //    HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        //    return null;
        //}

    }
}
