using Microsoft.EntityFrameworkCore;
using Modules.Pianos.Data;
using Modules.Pianos.Entities;
using Modules.Pianos.Interfaces;

namespace Modules.Pianos.Repositories;

public class PianoRepository(PianosDbContext context) : IPianoRepository
{
    private readonly PianosDbContext _context = context;
    
    public async Task<Piano> CreateAsync(Piano piano)
    {
        await _context.Pianos.AddAsync(piano);  
        await _context.SaveChangesAsync();
        return piano;
    }

    public async Task<Piano?> GetByIdAsync(Guid id)
    {
        return await _context.Pianos.FirstOrDefaultAsync(x => x.Id == id);
    }
}