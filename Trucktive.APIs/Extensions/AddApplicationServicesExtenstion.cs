using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Trucktive.Core.Repositories;
using Trucktive.Repositories._Data;
using Trucktive.Repositories.Repositories;

namespace Trucktive.APIs.Extensions
{
    public static class AddApplicationServicesExtenstion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();


            return Services;
        }
    }
}
