using Modules.Pianos;
using Modules.Violins;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddViolinsModule()
    .AddPianosModule();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();