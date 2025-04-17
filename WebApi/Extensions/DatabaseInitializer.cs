using Dapper;
using Npgsql;

namespace WebApi.Extensions;

internal sealed class DatabaseInitializer
    (
        NpgsqlDataSource dataSource, 
        IConfiguration configuration, 
        ILogger<DatabaseInitializer> logger
    )
{
    public async Task ExecuteAsync(CancellationToken stoppingToken = default)
    {
        try
        {
            logger.LogInformation("Starting database initialization");

            await EnsureDatabaseExists();
            await InitializeDatabase();
            
            logger.LogInformation("Database initialization completed successfully");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during database initialization");
        }
    }

    private async Task EnsureDatabaseExists()
    {
        string connectionString = configuration.GetConnectionString("Database")!;
        var builder = new NpgsqlConnectionStringBuilder(connectionString);
        string? databaseName = builder.Database;
        builder.Database = "postgres";
        
        using var connection = new NpgsqlConnection(builder.ToString());
        await connection.OpenAsync();

        bool databaseExists = await connection.ExecuteScalarAsync<bool>(
            "SELECT EXISTS(SELECT 1 FROM  pg_database WHERE datname = @databaseName)", new { databaseName });

        if (!databaseExists)
        {
            logger.LogInformation("Creating database '{databaseName}'", databaseName);
            await connection.ExecuteAsync($"CREATE DATABASE {databaseName}");
        }
    }

    private async Task InitializeDatabase()
    {
        const string sql = 
            """
            CREATE TABLE IF NOT EXISTS piano (
                id UUID PRIMARY KEY,
                model TEXT NOT NULL,
                brand TEXT NOT NULL,
                key_count INT NOT NULL,
                is_acoustic BOOLEAN NOT NULL,
                has_pedals BOOLEAN NOT NULL,
                body_material TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS violin (
                id UUID PRIMARY KEY,
                model TEXT NOT NULL,
                brand TEXT NOT NULL,
                size DECIMAL NOT NULL,
                string_material TEXT NOT NULL,
                body_wood TEXT NOT NULL,
                bow_material TEXT NOT NULL
            );
            """;

        using var connection = await dataSource.OpenConnectionAsync();
        await connection.ExecuteAsync(sql);
    }
}