using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using MarkDav.Splore.Repository;

namespace MarkDav.Splore.Manager
{
    public class SploreManager : MigratableModuleBase, IInstallable, IPortable
    {
        private ISploreRepository _SploreRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IHttpContextAccessor _accessor;

        public SploreManager(ISploreRepository SploreRepository, ITenantManager tenantManager, IHttpContextAccessor accessor)
        {
            _SploreRepository = SploreRepository;
            _tenantManager = tenantManager;
            _accessor = accessor;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new SploreContext(_tenantManager, _accessor), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new SploreContext(_tenantManager, _accessor), tenant, MigrationType.Down);
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.Splore> Splores = _SploreRepository.GetSplores(module.ModuleId).ToList();
            if (Splores != null)
            {
                content = JsonSerializer.Serialize(Splores);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.Splore> Splores = null;
            if (!string.IsNullOrEmpty(content))
            {
                Splores = JsonSerializer.Deserialize<List<Models.Splore>>(content);
            }
            if (Splores != null)
            {
                foreach(var Splore in Splores)
                {
                    _SploreRepository.AddSplore(new Models.Splore { ModuleId = module.ModuleId, Name = Splore.Name });
                }
            }
        }
    }
}