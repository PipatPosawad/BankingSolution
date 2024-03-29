using Banking.Repository;
using Banking.Service;
using Domain;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddSingleton<ILoggerFactory>(serviceProvider => LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    }))
    .AddSingleton(serviceProvider =>
    {
        var factory = serviceProvider.GetService<ILoggerFactory>();
        return factory?.CreateLogger("Common");
    });

builder.Services.AddHttpClient();
builder.Services
    .Configure<GeneratorSettings>(builder.Configuration.GetSection("Generator"));

builder.Services.AddScoped<IAccountNumberGenerator, AccountNumberGenerator>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddSingleton<IAccountRepository, AccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
