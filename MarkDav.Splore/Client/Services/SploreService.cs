using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using MarkDav.Splore.Models;

namespace MarkDav.Splore.Services
{
    public class SploreService : ServiceBase, ISploreService, IService
    {
        public SploreService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Splore");

        public async Task<List<Models.Splore>> GetSploresAsync(int ModuleId)
        {
            List<Models.Splore> Splores = await GetJsonAsync<List<Models.Splore>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId));
            return Splores.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Splore> GetSploreAsync(int SploreId, int ModuleId)
        {
            return await GetJsonAsync<Models.Splore>(CreateAuthorizationPolicyUrl($"{Apiurl}/{SploreId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.Splore> AddSploreAsync(Models.Splore Splore)
        {
            return await PostJsonAsync<Models.Splore>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, Splore.ModuleId), Splore);
        }

        public async Task<Models.Splore> UpdateSploreAsync(Models.Splore Splore)
        {
            return await PutJsonAsync<Models.Splore>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Splore.SploreId}", EntityNames.Module, Splore.ModuleId), Splore);
        }

        public async Task DeleteSploreAsync(int SploreId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{SploreId}", EntityNames.Module, ModuleId));
        }
    }
}
