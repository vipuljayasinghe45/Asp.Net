
using Application.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Persistance
{
    public static class DependecyInjecton
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("CoffeeshopConnection")));

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }


        
        
    }
}
