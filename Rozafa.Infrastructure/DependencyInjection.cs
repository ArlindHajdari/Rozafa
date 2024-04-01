using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rozafa.Application.Common.Interfaces;
using Rozafa.Infrastructure.Persistence;
using Rozafa.Infrastructure.Services;

namespace Rozafa.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager config)
    {
        services.AddSingleton<ICustomer, Customer>();
        services.AddAuth(config);
        services.AddPersistence(config);
        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services, 
        ConfigurationManager config)
    {
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).
            AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config.GetSection("Auth:URL").ToString(),
                ValidAudience = config.GetSection("Auth:URL").ToString(),
            });
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddDbContext<RozafaDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Rozafa"));
            });

        return services;
    }
}