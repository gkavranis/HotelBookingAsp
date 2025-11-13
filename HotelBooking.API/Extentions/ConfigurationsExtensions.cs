namespace HotelBooking.Api.Extensions;


using HotelBooking.Domain;

/// <summary>
/// Provides extension methods for configuring application settings and options.
/// </summary>
public static class ConfigurationsExtensions
{
    /// <summary>
    /// Binds configuration sections to strongly-typed configuration classes.
    /// Registers connection strings from appsettings.json to be injected via IOptions pattern.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configurations">The configuration instance containing application settings.</param>
    public static IServiceCollection BindConfigurations(
        this IServiceCollection services, IConfiguration configurations)
    {
        services.Configure<ConnectionStrings>(
            configurations.GetSection(nameof(ConnectionStrings)));

        return services;
    }
}
