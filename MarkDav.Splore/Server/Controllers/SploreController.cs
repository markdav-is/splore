using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using MarkDav.Splore.Repository;
using Oqtane.Controllers;
using System.Net;

namespace MarkDav.Splore.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class SploreController : ModuleControllerBase
    {
        private readonly ISploreRepository _SploreRepository;

        public SploreController(ISploreRepository SploreRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _SploreRepository = SploreRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Splore> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && ModuleId == AuthEntityId(EntityNames.Module))
            {
                return _SploreRepository.GetSplores(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Splore Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Splore Get(int id)
        {
            Models.Splore Splore = _SploreRepository.GetSplore(id);
            if (Splore != null && Splore.ModuleId == AuthEntityId(EntityNames.Module))
            {
                return Splore;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Splore Get Attempt {SploreId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Splore Post([FromBody] Models.Splore Splore)
        {
            if (ModelState.IsValid && Splore.ModuleId == AuthEntityId(EntityNames.Module))
            {
                Splore = _SploreRepository.AddSplore(Splore);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Splore Added {Splore}", Splore);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Splore Post Attempt {Splore}", Splore);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Splore = null;
            }
            return Splore;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Splore Put(int id, [FromBody] Models.Splore Splore)
        {
            if (ModelState.IsValid && Splore.ModuleId == AuthEntityId(EntityNames.Module) && _SploreRepository.GetSplore(Splore.SploreId, false) != null)
            {
                Splore = _SploreRepository.UpdateSplore(Splore);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Splore Updated {Splore}", Splore);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Splore Put Attempt {Splore}", Splore);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Splore = null;
            }
            return Splore;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Splore Splore = _SploreRepository.GetSplore(id);
            if (Splore != null && Splore.ModuleId == AuthEntityId(EntityNames.Module))
            {
                _SploreRepository.DeleteSplore(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Splore Deleted {SploreId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Splore Delete Attempt {SploreId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
