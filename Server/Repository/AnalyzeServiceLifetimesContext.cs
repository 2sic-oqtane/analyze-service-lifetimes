using Microsoft.EntityFrameworkCore;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Repository.Databases.Interfaces;

namespace ToSic.Module.AnalyzeServiceLifetimes.Repository
{
    public class AnalyzeServiceLifetimesContext(IDBContextDependencies dbContextDependencies)
        : DBContextBase(dbContextDependencies), ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.AnalyzeServiceLifetimes> AnalyzeServiceLifetimes { get; set; }

        // ContextBase handles multi-tenant database connections

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.AnalyzeServiceLifetimes>().ToTable(ActiveDatabase.RewriteName("ToSicAnalyzeServiceLifetimes"));
        }
    }
}
