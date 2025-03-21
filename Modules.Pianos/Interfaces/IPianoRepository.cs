using Modules.Pianos.Entities;

namespace Modules.Pianos.Interfaces;

public interface IPianoRepository
{
    Task<Piano> CreateAsync(Piano piano);
    Task<Piano?> GetByIdAsync(Guid id);
}