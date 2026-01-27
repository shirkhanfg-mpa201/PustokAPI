using Microsoft.Extensions.DependencyInjection;
using Pustok.Business.Services.Abstractions;
using Pustok.Business.Services.Implementations;
using Pustok.DataAccess.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.ServiceRegistirations
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services )
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(_ =>{ },typeof(BusinessServiceRegistration).Assembly);
        }
    }
}
