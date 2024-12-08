using iNUPCO.SHO.Service.GoodService;
using iNUPCO.SHO.Service.PODocumentService;
using iNUPCO.SHO.Service.RabbitMQSrervice;
using iNUPCO.SHO.Service.SHOService;
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
            services.AddScoped<IPOService, PODocumentService.POService>();
            services.AddScoped<IGoodService, GoodService.GoodService>();
            services.AddScoped<ISHOService, SHOService.SHOService>();
            services.AddSingleton<IRabbitMQService, RabbitMQService>();
            return services;
        }
    }
}
