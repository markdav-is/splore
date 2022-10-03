using Microsoft.Extensions.DependencyInjection;
using Oqtane.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;

namespace MarkDav.SploreTheme.Client.Startup
{
    internal class Startup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMudServices();
        }
    }
}
