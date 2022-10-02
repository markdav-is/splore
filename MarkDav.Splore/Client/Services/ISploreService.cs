using System.Collections.Generic;
using System.Threading.Tasks;
using MarkDav.Splore.Models;

namespace MarkDav.Splore.Services
{
    public interface ISploreService 
    {
        Task<List<Models.Splore>> GetSploresAsync(int ModuleId);

        Task<Models.Splore> GetSploreAsync(int SploreId, int ModuleId);

        Task<Models.Splore> AddSploreAsync(Models.Splore Splore);

        Task<Models.Splore> UpdateSploreAsync(Models.Splore Splore);

        Task DeleteSploreAsync(int SploreId, int ModuleId);
    }
}
