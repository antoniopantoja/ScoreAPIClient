using Teste.ScoreAPI.Api.Middleware;
using Teste.ScoreAPI.Application.Interfaces;
using Teste.ScoreAPI.Application.Services;
using Teste.ScoreAPI.Domain.Interfaces;
using Teste.ScoreAPI.Infrastructure.Data;
using Teste.ScoreAPI.Infrastructure.Repositories;
using Teste.ScoreAPI.Infrastructure.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
builder.Services.AddScoped<ICpfValidator, CpfValidator>();
builder.Services.AddScoped<IScoreCalculator, ScoreCalculator>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ConnectionFactory>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var connectionFactory = scope.ServiceProvider.GetRequiredService<ConnectionFactory>();

    try
    {
        using var connection = connectionFactory.Create();
        await connection.OpenAsync();

        Console.WriteLine("Database connection established.");
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "Failed to establish database connection at startup.");
        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
