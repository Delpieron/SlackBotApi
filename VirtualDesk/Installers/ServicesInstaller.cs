using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualDesk.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IProductsService, ProductsService>();
            //services.AddScoped<IUsersService, UsersService>();
            //services.AddScoped<ICategoriesService, CategoriesService>();
        }
    }
}
