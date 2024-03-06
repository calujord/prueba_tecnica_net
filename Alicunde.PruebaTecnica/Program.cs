using Alicunde.PruebaTecnica.Data;
using Alicunde.PruebaTecnica.Mapping;
using Alicunde.PruebaTecnica.Repositories;
using Alicunde.PruebaTecnica.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
// Logging providers
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Add database context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDatabaseContext>(options =>
    options.UseSqlServer(connectionString));


// Repositories
builder.Services.AddScoped<IFeeRepository, FeeRepository>();

// Custom service
builder.Services.AddScoped<FeeService>();

// Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// External Services
builder.Services.AddHttpClient<EsettService>();

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
