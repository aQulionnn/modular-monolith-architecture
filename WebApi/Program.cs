using Modules.Pianos;
using Modules.Violins;
using Npgsql;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton(_ => new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("Database")).Build());

builder.Services
    .AddViolinsModule(builder.Configuration)
    .AddPianosModule(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.Services.GetRequiredService<DatabaseInitializer>().ExecuteAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();