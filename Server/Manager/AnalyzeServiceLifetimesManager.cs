using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using ToSic.Module.AnalyzeServiceLifetimes.Repository;

namespace ToSic.Module.AnalyzeServiceLifetimes.Manager;

public class AnalyzeServiceLifetimesManager(
    IAnalyzeServiceLifetimesRepository analyzeServiceLifetimesRepository,
    IDBContextDependencies dbContextDependencies)
    : MigratableModuleBase, IInstallable, IPortable
{
    public bool Install(Tenant tenant, string version) => Migrate(new AnalyzeServiceLifetimesContext(dbContextDependencies), tenant, MigrationType.Up);

    public bool Uninstall(Tenant tenant) => Migrate(new AnalyzeServiceLifetimesContext(dbContextDependencies), tenant, MigrationType.Down);

    public string ExportModule(Oqtane.Models.Module module)
    {
        var content = "";
        var AnalyzeServiceLifetimess = analyzeServiceLifetimesRepository.GetAnalyzeServiceLifetimess(module.ModuleId).ToList();
        if (AnalyzeServiceLifetimess != null)
            content = JsonSerializer.Serialize(AnalyzeServiceLifetimess);
        return content;
    }

    public void ImportModule(Oqtane.Models.Module module, string content, string version)
    {
        List<Models.AnalyzeServiceLifetimes> analyzeServiceLifetimess = null;
        if (!string.IsNullOrEmpty(content))
            analyzeServiceLifetimess = JsonSerializer.Deserialize<List<Models.AnalyzeServiceLifetimes>>(content);
        
        if (analyzeServiceLifetimess != null)
            foreach(var AnalyzeServiceLifetimes in analyzeServiceLifetimess)
                analyzeServiceLifetimesRepository.AddAnalyzeServiceLifetimes(new Models.AnalyzeServiceLifetimes { ModuleId = module.ModuleId, Name = AnalyzeServiceLifetimes.Name });
    }

}