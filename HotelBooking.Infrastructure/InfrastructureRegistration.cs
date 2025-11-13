namespace HotelBooking.Infrastructure;

using HotelBooking.Domain.Repositories;
using HotelBooking.Infrastructure.Mappings;
using HotelBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Registers the infrastructure services required by the application, including database context, repositories, and
/// AutoMapper configurations.
/// </summary>
/// <remarks>This method configures the application's infrastructure layer by: <list type="bullet">
/// <item><description>Registering the <see cref="HotelBookingDbContext"/> with SQL Server as the database provider and
/// query tracking disabled.</description></item> <item><description>Adding AutoMapper with the <see
/// cref="DomainMapping"/> profile.</description></item> <item><description>Registering repository implementations for
/// hotel, room, booking, and data management.</description></item> </list></remarks>
public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register DbContext
        services.AddDbContext<HotelBookingDbContext>(options =>
           {
               var connection = configuration["Database:ConnectionString"];
               options.UseSqlServer(connection);
               options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
           });

        // Register AutoMapper
        services.AddAutoMapper(cfg => cfg.AddProfile<DomainMapping>());

        // Register repositories
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IDataRepository, DataRepository>();

        return services;
    }
}
