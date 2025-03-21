using Microsoft.EntityFrameworkCore;
using Modules.Violins.Data;
using Modules.Violins.Entities;
using Modules.Violins.Interfaces;

namespace Modules.Violins.Repositories;

public class ViolinRepository(ViolinsDbContext context) : IViolinRepository
{
    private readonly ViolinsDbContext _context = context;

    public async Task<Violin> CreateAsync(Violin violin)
    {
        await _context.Violins.AddAsync(violin);
        await _context.SaveChangesAsync();
        return violin;
    }

    public async Task<Violin?> GetByIdAsync(Guid id)
    {
        return await _context.Violins.FirstOrDefaultAsync(x => x.Id == id);
    }
}