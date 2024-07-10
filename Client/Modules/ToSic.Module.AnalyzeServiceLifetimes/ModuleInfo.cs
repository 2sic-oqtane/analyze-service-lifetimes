using Oqtane.Models;
using Oqtane.Modules;

namespace ToSic.Module.AnalyzeServiceLifetimes
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new()
        {
            Name = "AnalyzeServiceLifetimes",
            Description = "App to see the real service lifetimes in all kinds of rendering scenarios.",
            Version = "1.0.0",
            ServerManagerType = "ToSic.Module.AnalyzeServiceLifetimes.Manager.AnalyzeServiceLifetimesManager, ToSic.Module.AnalyzeServiceLifetimes.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "ToSic.Module.AnalyzeServiceLifetimes.Shared.Oqtane",
            PackageName = "ToSic.Module.AnalyzeServiceLifetimes" 
        };
    }
}
