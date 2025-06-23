using Microsoft.EntityFrameworkCore;
using Vesta.Fullstack.Application.Services;
using Vesta.Fullstack.Domain.Contracts;
using Vesta.Fullstack.Infrastructure.DbContexts;
using Vesta.Fullstack.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddScoped<IStorage, OrderRepository>()
    .AddScoped<OrderService>()
    .AddDbContext<PostgresDbContext>(options =>
        options
            .UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))
    );

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
