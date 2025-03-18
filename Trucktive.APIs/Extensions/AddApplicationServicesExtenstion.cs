using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Trucktive.Core.Repositories;
using Trucktive.Core.Services;
using Trucktive.Repositories._Data;
using Trucktive.Repositories.Repositories;
using Trucktive.Services;

namespace Trucktive.APIs.Extensions
{
    public static class AddApplicationServicesExtenstion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            Services.AddSwaggerServices();

            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IAuthService, AuthService>();


            return Services;
        }
        private static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Survey Basket",
                        Description = "Survey Basket"
                    });

                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "JWT Authorization header using the Bearer scheme. " +
                        "\r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                     new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"},
                     Name = "Bearer",
                     In = ParameterLocation.Header

                },

                    new List<string>()
                } });
                }
                );

            return services;
        }
    }
}
