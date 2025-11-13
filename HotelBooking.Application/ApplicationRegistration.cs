namespace HotelBooking.Application;

using HotelBooking.Application.Services;
using HotelBooking.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        // Register application services
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IDataService, DataService>();
        // Register FluentValidation validators using 
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Scoped);
        return services;
    }
}