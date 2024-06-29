// <copyright file="DependencyInjection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
        IApplicationConfiguration _config = services.BuildServiceProvider().GetService<IApplicationConfiguration>()!;
        services.AddAuth(_config);
        services.AddPersistence(config);
        services.ConfigureHttpClient(_config);
        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        IApplicationConfiguration config)
    {
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).
            AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config.Auth.baseUrl,
                ValidAudience = config.Auth.baseUrl,
            });
        return services;
    }

#pragma warning disable SA1600 // Elements should be documented
    public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager config)
#pragma warning restore SA1600 // Elements should be documented
    {
        //services.AddDbContext<RozafaDbContext>(options => options.UseSqlServer(config.GetConnectionString("Rozafa")));

        return services;
    }

#pragma warning disable SA1600 // Elements should be documented
    public static IServiceCollection ConfigureHttpClient(this IServiceCollection services, IApplicationConfiguration config)
#pragma warning restore SA1600 // Elements should be documented
    {
        services.AddHttpClient(nameof(config.RICE), client =>
        {
            client.BaseAddress = new Uri(config.RICE.BaseURL);
            client.Timeout = TimeSpan.FromSeconds(10);
        });

        services.AddHttpClient(nameof(config.Auth), client =>
        {
            client.BaseAddress = new Uri(config.Auth.baseUrl);
            client.Timeout = TimeSpan.FromSeconds(10);
        });

        return services;
    }
}