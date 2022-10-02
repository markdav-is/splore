using Oqtane.Models;
using Oqtane.Modules;

namespace MarkDav.Splore
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Splore",
            Description = "Splore",
            Version = "1.0.0",
            ServerManagerType = "MarkDav.Splore.Manager.SploreManager, MarkDav.Splore.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "MarkDav.Splore.Shared.Oqtane",
            PackageName = "MarkDav.Splore" 
        };
    }
}
