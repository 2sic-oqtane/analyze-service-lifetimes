using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using System.Threading.Tasks;

namespace ToSic.Module.AnalyzeServiceLifetimes.Repository
{
    public class AnalyzeServiceLifetimesRepository(IDbContextFactory<AnalyzeServiceLifetimesContext> factory)
        : IAnalyzeServiceLifetimesRepository, ITransientService
    {
        public IEnumerable<Models.AnalyzeServiceLifetimes> GetAnalyzeServiceLifetimess(int ModuleId)
        {
            using var db = factory.CreateDbContext();
            return db.AnalyzeServiceLifetimes.Where(item => item.ModuleId == ModuleId).ToList();
        }

        public Models.AnalyzeServiceLifetimes GetAnalyzeServiceLifetimes(int AnalyzeServiceLifetimesId)
        {
            return GetAnalyzeServiceLifetimes(AnalyzeServiceLifetimesId, true);
        }

        public Models.AnalyzeServiceLifetimes GetAnalyzeServiceLifetimes(int AnalyzeServiceLifetimesId, bool tracking)
        {
            using var db = factory.CreateDbContext();
            return tracking
                ? db.AnalyzeServiceLifetimes.Find(AnalyzeServiceLifetimesId)
                : db.AnalyzeServiceLifetimes.AsNoTracking().FirstOrDefault(item => item.AnalyzeServiceLifetimesId == AnalyzeServiceLifetimesId);
        }

        public Models.AnalyzeServiceLifetimes AddAnalyzeServiceLifetimes(Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes)
        {
            using var db = factory.CreateDbContext();
            db.AnalyzeServiceLifetimes.Add(AnalyzeServiceLifetimes);
            db.SaveChanges();
            return AnalyzeServiceLifetimes;
        }

        public Models.AnalyzeServiceLifetimes UpdateAnalyzeServiceLifetimes(Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes)
        {
            using var db = factory.CreateDbContext();
            db.Entry(AnalyzeServiceLifetimes).State = EntityState.Modified;
            db.SaveChanges();
            return AnalyzeServiceLifetimes;
        }

        public void DeleteAnalyzeServiceLifetimes(int AnalyzeServiceLifetimesId)
        {
            using var db = factory.CreateDbContext();
            var AnalyzeServiceLifetimes = db.AnalyzeServiceLifetimes.Find(AnalyzeServiceLifetimesId);
            db.AnalyzeServiceLifetimes.Remove(AnalyzeServiceLifetimes);
            db.SaveChanges();
        }


        public async Task<IEnumerable<Models.AnalyzeServiceLifetimes>> GetAnalyzeServiceLifetimessAsync(int ModuleId)
        {
            using var db = factory.CreateDbContext();
            return await db.AnalyzeServiceLifetimes.Where(item => item.ModuleId == ModuleId).ToListAsync();
        }

        public async Task<Models.AnalyzeServiceLifetimes> GetAnalyzeServiceLifetimesAsync(int AnalyzeServiceLifetimesId)
        {
            return await GetAnalyzeServiceLifetimesAsync(AnalyzeServiceLifetimesId, true);
        }

        public async Task<Models.AnalyzeServiceLifetimes> GetAnalyzeServiceLifetimesAsync(int AnalyzeServiceLifetimesId, bool tracking)
        {
            using var db = factory.CreateDbContext();
            return tracking
                ? await db.AnalyzeServiceLifetimes.FindAsync(AnalyzeServiceLifetimesId)
                : await db.AnalyzeServiceLifetimes.AsNoTracking().FirstOrDefaultAsync(item =>
                    item.AnalyzeServiceLifetimesId == AnalyzeServiceLifetimesId);
        }

        public async Task<Models.AnalyzeServiceLifetimes> AddAnalyzeServiceLifetimesAsync(Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes)
        {
            using var db = factory.CreateDbContext();
            db.AnalyzeServiceLifetimes.Add(AnalyzeServiceLifetimes);
            await db.SaveChangesAsync();
            return AnalyzeServiceLifetimes;
        }

        public async Task<Models.AnalyzeServiceLifetimes> UpdateAnalyzeServiceLifetimesAsync(Models.AnalyzeServiceLifetimes AnalyzeServiceLifetimes)
        {
            using var db = factory.CreateDbContext();
            db.Entry(AnalyzeServiceLifetimes).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return AnalyzeServiceLifetimes;
        }

        public async Task DeleteAnalyzeServiceLifetimesAsync(int AnalyzeServiceLifetimesId)
        {
            using var db = factory.CreateDbContext();
            var AnalyzeServiceLifetimes = db.AnalyzeServiceLifetimes.Find(AnalyzeServiceLifetimesId);
            db.AnalyzeServiceLifetimes.Remove(AnalyzeServiceLifetimes);
            await db.SaveChangesAsync();
        }
    }
}
