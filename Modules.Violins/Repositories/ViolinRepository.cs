using Dapper;
using Modules.Violins.Data;
using Modules.Violins.Entities;
using Modules.Violins.Interfaces;

namespace Modules.Violins.Repositories;

public class ViolinRepository(IDbConnectionFactory connectionFactory) : IViolinRepository
{
    private readonly IDbConnectionFactory _connectionFactory = connectionFactory;
    
    public async Task<Violin> CreateAsync(Violin violin)
    {
        using var dbConnection = await _connectionFactory.CreateConnectionAsync();
        await dbConnection.ExecuteAsync(
            """
            INSERT INTO violins (id, model, brand, size, stringmaterial, bodywood, bowmaterial)
            VALUES (@Id, @Model, @Brand, @Size, @StringMaterial, @BodyWood, @BowMaterial)
            """, violin);
        
        return violin;
    }

    public async Task<Violin?> GetByIdAsync(Guid id)
    {
        using var dbConnection = await _connectionFactory.CreateConnectionAsync();
        return await dbConnection.QueryFirstOrDefaultAsync<Violin>("SELECT * FROM violins WHERE id = @Id", new { Id = id });
    }
}