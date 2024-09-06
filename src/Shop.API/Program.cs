using Microsoft.EntityFrameworkCore;
using Serilog;
using Shop.Application;
using Shop.Application.Contracts;
using Shop.Domain;
using Shop.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog();

// DbContext.
services.AddDbContext<ShopDbContext>(cfg =>
{
    cfg.UseNpgsql(configuration.GetConnectionString("Default"));
});

// Services.
services.AddTransient<IPersonAppService, PersonAppService>();

// Repositories.
services.AddTransient<IPersonRepository, PersonRepository>();

// Mapper.
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();