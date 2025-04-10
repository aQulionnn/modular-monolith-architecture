using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Pianos.Data;
using Modules.Pianos.Interfaces;
using Modules.Pianos.Repositories;

namespace Modules.Pianos;

public static class DependencyInjection
{
    public static IServiceCollection AddPianosModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDbConnectionFactory>(_ => new NpgsqlDbConnectionFactory(configuration.GetConnectionString("Database")!));
        services.AddScoped<IPianoRepository, PianoRepository>();
        return services;
    }
}