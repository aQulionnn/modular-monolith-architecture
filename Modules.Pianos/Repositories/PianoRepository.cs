using Dapper;
using Modules.Pianos.Data;
using Modules.Pianos.Entities;
using Modules.Pianos.Interfaces;

namespace Modules.Pianos.Repositories;

public class PianoRepository(IDbConnectionFactory connectionFactory) : IPianoRepository
{
    private readonly IDbConnectionFactory _connectionFactory = connectionFactory;
    
    public async Task<Piano> CreateAsync(Piano piano)
    {
        using var dbConnection = await _connectionFactory.CreateConnectionAsync();
        await dbConnection.ExecuteAsync(
            """
            INSERT INTO pianos (id, model, brand, keycount, isacoustic, haspedals, bodymaterial)
            VALUES (@Id, @Model, @Brand, @KeyCount, @IsAcoustic, @HasPedals, @BodyMaterial)
            """, piano);
        
        return piano;
    }

    public async Task<Piano?> GetByIdAsync(Guid id)
    {
        using var dbConnection = await _connectionFactory.CreateConnectionAsync();
        return await dbConnection.QuerySingleOrDefaultAsync<Piano>("SELECT * FROM pianos WHERE id = @Id", id);
    }
}