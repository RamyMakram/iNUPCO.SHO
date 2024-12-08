using iNUPCO.SHO.Service.GoodService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.Service
{
    public static class Infra_RegisterAllServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<PODocumentService.IPOService, PODocumentService.POService>();
            services.AddScoped<IGoodService, GoodService.GoodService>();
            return services;
        }
    }
}
