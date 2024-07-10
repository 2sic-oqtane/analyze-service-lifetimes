using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using ToSic.Module.AnalyzeServiceLifetimes.Repository;

namespace ToSic.Module.AnalyzeServiceLifetimes.Manager;

public class AnalyzeServiceLifetimesManager(
    IDBContextDependencies dbContextDependencies)
    : MigratableModuleBase, IInstallable, IPortable
{
    public bool Install(Tenant tenant, string version) => Migrate(new AnalyzeServiceLifetimesContext(dbContextDependencies), tenant, MigrationType.Up);

    public bool Uninstall(Tenant tenant) => Migrate(new AnalyzeServiceLifetimesContext(dbContextDependencies), tenant, MigrationType.Down);

    public string ExportModule(Oqtane.Models.Module module) => ""; // do nothing

    public void ImportModule(Oqtane.Models.Module module, string content, string version)
    {
        /* do nothing */
    }

}