using Modules.Violins.Entities;

namespace Modules.Violins.Interfaces;

public interface IViolinRepository
{
    Task<Violin> CreateAsync(Violin violin);
    Task<Violin?> GetByIdAsync(Guid id);
}