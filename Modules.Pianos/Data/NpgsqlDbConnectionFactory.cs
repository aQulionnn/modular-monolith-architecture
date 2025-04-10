using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Modules.Pianos.Data;

public class NpgsqlDbConnectionFactory(string connectionString) : IDbConnectionFactory
{
    private readonly string _connectionString = connectionString;
    
    public async Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }
}

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default);
}