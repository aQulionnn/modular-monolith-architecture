using Microsoft.EntityFrameworkCore;
using Modules.Pianos.Entities;

namespace Modules.Pianos.Data;

public class PianosDbContext(DbContextOptions<PianosDbContext> options) : DbContext(options)
{
    public DbSet<Piano> Pianos { get; set; }
}