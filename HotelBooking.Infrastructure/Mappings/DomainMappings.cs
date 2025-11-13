namespace HotelBooking.Infrastructure.Mappings;
using AutoMapper;

using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Tables;

public class DomainMapping : Profile
{
    public DomainMapping()
    {
        CreateMap<Hotel, HotelDBEntity>();
        CreateMap<HotelDBEntity, Hotel>();
        CreateMap<Room, RoomDbEntity>();
        CreateMap<RoomDbEntity, Room>();

        CreateMap<BookingDBEntity, Booking>()
            .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room));

        CreateMap<Booking, BookingDBEntity>()
            .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.Room.Id))
            .ForMember(dest => dest.Room, opt => opt.Ignore());

    }
}
