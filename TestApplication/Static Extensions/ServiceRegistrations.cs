using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Services;

namespace TestApplication.Static_Extensions
{
    public static class ServiceRegistrations
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IInterestCalcService, InterestCalcService>();
        }
    }
}
