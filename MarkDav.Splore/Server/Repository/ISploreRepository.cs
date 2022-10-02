using System.Collections.Generic;
using MarkDav.Splore.Models;

namespace MarkDav.Splore.Repository
{
    public interface ISploreRepository
    {
        IEnumerable<Models.Splore> GetSplores(int ModuleId);
        Models.Splore GetSplore(int SploreId);
        Models.Splore GetSplore(int SploreId, bool tracking);
        Models.Splore AddSplore(Models.Splore Splore);
        Models.Splore UpdateSplore(Models.Splore Splore);
        void DeleteSplore(int SploreId);
    }
}
