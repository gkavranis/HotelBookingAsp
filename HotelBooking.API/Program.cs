using HotelBooking.Api.Extensions;
using HotelBooking.Api.Middleware;
using HotelBooking.API.Mapping;
using HotelBooking.API.MIddleware;
using HotelBooking.Application;
using HotelBooking.Infrastructure;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Enhanced Swagger configuration with XML comments
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Hotel Booking API",
        Description = "An ASP.NET Core Web API for managing hotel bookings, rooms, and hotels",
    });

    // Include XML comments from API project
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    // Include XML comments from Contracts project
    var contractsXmlFile = "HotelBooking.Contracts.xml";
    var contractsXmlPath = Path.Combine(AppContext.BaseDirectory, contractsXmlFile);
    if (File.Exists(contractsXmlPath))
    {
        options.IncludeXmlComments(contractsXmlPath);
    }
});

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ContractMapping>());
builder.Services.BindConfigurations(builder.Configuration);

// Register Application services
builder.Services.AddApplication();

// Register Infrastructure services (includes DbContext)
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Booking API v1");
        options.RoutePrefix = "swagger"; 
        options.DocumentTitle = "Hotel Booking API Documentation";
    });
}

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseMiddleware<ValidationMappingMiddleware>();

app.MapControllers();

app.Run();



