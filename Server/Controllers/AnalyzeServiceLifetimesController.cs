using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using ToSic.Module.AnalyzeServiceLifetimes.Repository;
using Oqtane.Controllers;
using System.Net;

namespace ToSic.Module.AnalyzeServiceLifetimes.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class AnalyzeServiceLifetimesController(
        IAnalyzeServiceLifetimesRepository analyzeServiceLifetimesRepository,
        ILogManager logger,
        IHttpContextAccessor accessor)
        : ModuleControllerBase(logger, accessor)
    {
        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.AnalyzeServiceLifetimes> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
                return analyzeServiceLifetimesRepository.GetAnalyzeServiceLifetimess(ModuleId);
            
            _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Get Attempt {ModuleId}", moduleid);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return null;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.AnalyzeServiceLifetimes Get(int id)
        {
            var AnalyzeServiceLifetimes = analyzeServiceLifetimesRepository.GetAnalyzeServiceLifetimes(id);
            if (AnalyzeServiceLifetimes != null && IsAuthorizedEntityId(EntityNames.Module, AnalyzeServiceLifetimes.ModuleId))
                return AnalyzeServiceLifetimes;

            _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Get Attempt {AnalyzeServiceLifetimesId}", id);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return null;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.AnalyzeServiceLifetimes Post([FromBody] Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, AnalyzeServiceLifetimes.ModuleId))
            {
                AnalyzeServiceLifetimes = analyzeServiceLifetimesRepository.AddAnalyzeServiceLifetimes(AnalyzeServiceLifetimes);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "AnalyzeServiceLifetimes Added {AnalyzeServiceLifetimes}", AnalyzeServiceLifetimes);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Post Attempt {AnalyzeServiceLifetimes}", AnalyzeServiceLifetimes);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                AnalyzeServiceLifetimes = null;
            }
            return AnalyzeServiceLifetimes;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.AnalyzeServiceLifetimes Put(int id, [FromBody] Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes)
        {
            if (ModelState.IsValid && AnalyzeServiceLifetimes.AnalyzeServiceLifetimesId == id && IsAuthorizedEntityId(EntityNames.Module, AnalyzeServiceLifetimes.ModuleId) && analyzeServiceLifetimesRepository.GetAnalyzeServiceLifetimes(AnalyzeServiceLifetimes.AnalyzeServiceLifetimesId, false) != null)
            {
                AnalyzeServiceLifetimes = analyzeServiceLifetimesRepository.UpdateAnalyzeServiceLifetimes(AnalyzeServiceLifetimes);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "AnalyzeServiceLifetimes Updated {AnalyzeServiceLifetimes}", AnalyzeServiceLifetimes);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Put Attempt {AnalyzeServiceLifetimes}", AnalyzeServiceLifetimes);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                AnalyzeServiceLifetimes = null;
            }
            return AnalyzeServiceLifetimes;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            var AnalyzeServiceLifetimes = analyzeServiceLifetimesRepository.GetAnalyzeServiceLifetimes(id);
            if (AnalyzeServiceLifetimes != null && IsAuthorizedEntityId(EntityNames.Module, AnalyzeServiceLifetimes.ModuleId))
            {
                analyzeServiceLifetimesRepository.DeleteAnalyzeServiceLifetimes(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "AnalyzeServiceLifetimes Deleted {AnalyzeServiceLifetimesId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized AnalyzeServiceLifetimes Delete Attempt {AnalyzeServiceLifetimesId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
