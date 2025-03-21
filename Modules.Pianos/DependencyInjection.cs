using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Pianos.Data;
using Modules.Pianos.Interfaces;
using Modules.Pianos.Repositories;

namespace Modules.Pianos;

public static class DependencyInjection
{
    public static IServiceCollection AddPianosModule(this IServiceCollection services)
    {
        services.AddDbContext<PianosDbContext>(options => options.UseInMemoryDatabase("Database"));
        services.AddScoped<IPianoRepository, PianoRepository>();
        return services;
    }
}