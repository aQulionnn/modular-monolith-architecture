using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Violins.Data;
using Modules.Violins.Interfaces;
using Modules.Violins.Repositories;

namespace Modules.Violins;

public static class DependencyInjection
{
    public static IServiceCollection AddViolinsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDbConnectionFactory>(_ => new NpgsqlDbConnectionFactory(configuration.GetConnectionString("Database")!));
        services.AddScoped<IViolinRepository, ViolinRepository>();
        return services;
    }
}