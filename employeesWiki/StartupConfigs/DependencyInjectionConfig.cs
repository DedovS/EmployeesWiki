using employeesWiki.Contracts.Core;
using employeesWiki.Contracts.Services;
using employeesWiki.Core;
using employeesWiki.Services;
using Microsoft.Extensions.DependencyInjection;

namespace employeesWiki.StartupConfigs
{
    public class DependencyInjectionConfig
    {
        public static void AddScoped(IServiceCollection services)
        {
            services.AddScoped<IWikiService, WikiService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}