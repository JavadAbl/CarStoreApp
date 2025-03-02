using System.Text;
using CarStoreApp.Server.Data;
using CarStoreApp.Server.Interfaces;
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
            services.AddScoped<IJWTService, JWTService>();
            return services;
        }

        public static IServiceCollection AddAppDbService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDBContext>(op =>
             {
                 op.UseSqlite(config.GetConnectionString("main"));

             }, ServiceLifetime.Scoped);
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
