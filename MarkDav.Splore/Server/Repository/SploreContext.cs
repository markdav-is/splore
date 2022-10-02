using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace MarkDav.Splore.Repository
{
    public class SploreContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.Splore> Splore { get; set; }

        public SploreContext(ITenantManager tenantManager, IHttpContextAccessor accessor) : base(tenantManager, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
