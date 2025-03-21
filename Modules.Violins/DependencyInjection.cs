using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Violins.Data;
using Modules.Violins.Interfaces;
using Modules.Violins.Repositories;

namespace Modules.Violins;

public static class DependencyInjection
{
    public static IServiceCollection AddViolinsModule(this IServiceCollection services)
    {
        services.AddDbContext<ViolinsDbContext>(options => options.UseInMemoryDatabase("Database"));
        services.AddScoped<IViolinRepository, ViolinRepository>();
        return services;
    }
}