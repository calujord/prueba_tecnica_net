using Microsoft.OpenApi.Models;
using System.Reflection;
using PruebaTecnicaNet.API;
using PruebaTecnicaNet.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();
builder.AddDefaultOpenApi();
builder.AddApplicationServices();

builder.Services.AddProblemDetails();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

// Add OpenAPI 3.0 document serving middleware
// Available at: http://localhost:<port>/swagger/v1/swagger.json
app.UseOpenApi();

// Add web UIs to interact with the document
// Available at: http://localhost:<port>/swagger
app.UseSwaggerUi(options =>
{
    options.DocumentTitle = "PruebaTecnicaNet API";
    options.Path = "/swagger";
    options.DocumentPath = "/swagger/v1/swagger.json";
});

app.UseDefaultOpenApi();

app.MapDefaultEndpoints();

app.MapGroup("/api/v1/settlementbanks")
   .MapPruebaTecnicaNetApi();

app.Run();
