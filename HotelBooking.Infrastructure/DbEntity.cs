namespace HotelBooking.Infrastructure;

/// <summary>
/// Represents a base entity with a unique identifier, typically used in database models.
/// </summary>
/// <remarks>This class serves as a base type for entities that require a unique identifier. The <see cref="Id"/>
/// property is required and must be set to a valid <see cref="Guid"/> value.</remarks>
internal class DbEntity
{
    public required Guid Id { get; set; }
}