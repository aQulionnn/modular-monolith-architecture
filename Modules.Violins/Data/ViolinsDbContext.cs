using Microsoft.EntityFrameworkCore;
using Modules.Violins.Entities;

namespace Modules.Violins.Data;

public class ViolinsDbContext(DbContextOptions<ViolinsDbContext> options) : DbContext(options)
{
    public DbSet<Violin> Violins { get; set; }
}