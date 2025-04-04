using System.Text;
using CarStoreApp.Server.Data;
using CarStoreApp.Server.Data.Repositories;
using CarStoreApp.Server.Helpers;
using CarStoreApp.Server.Interfaces.Repositories;
using CarStoreApp.Server.Interfaces.Services;
using CarStoreApp.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CarStoreApp.Server.Extentions
{
    public static class AppServicesExtentions
    {

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            return services;
        }

        public static IServiceCollection AddAppDbService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDBContext>(op =>
             {
                 op.UseSqlite(config.GetConnectionString("main"));

             }, ServiceLifetime.Scoped);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarRepository, CarRepository>();


            return services;
        }

        public static IServiceCollection AddAppAuth(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
         {
             var jwtSettings = config.GetSection("JWT").Get<JWTSettings>() ?? throw new Exception("Cannot get jwt config");

             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = false,
                 ValidateAudience = false,
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
             };
         });
            return services;
        }

    }
}
