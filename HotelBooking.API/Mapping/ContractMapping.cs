namespace HotelBooking.API.Mapping;

using AutoMapper;
using HotelBooking.Contracts.Requests;
using HotelBooking.Contracts.Responses;
using HotelBooking.Domain.Entities;

public class ContractMapping : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContractMapping"/> class.
    /// Configures all mapping rules between domain models and API contracts.
    /// </summary>
    public ContractMapping()
    {
        CreateMap<Hotel, GetHotelResponse>();
        CreateMap<Room, GetAvailableRoomsResponse>();

        CreateMap<CreateBookingRequest, Booking>()
            .ForMember(dest => dest.StartingDate, opt => opt.MapFrom(src => DateTime.Parse(src.FromDate)))
            .ForMember(dest => dest.EndingDate, opt => opt.MapFrom(src => DateTime.Parse(src.ToDate)))
            .ForMember(dest => dest.Room, opt => opt.MapFrom(src => new Room { Id = src.RoomId, Type = string.Empty }));

        CreateMap<GetAvailableRoomsRequest, RoomQuery>()
            .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.HotelId))
            .ForMember(dest => dest.FromDate, opt => opt.MapFrom(src => DateTime.Parse(src.FromDate)))
            .ForMember(dest => dest.ToDate, opt => opt.MapFrom(src => DateTime.Parse(src.ToDate)))
            .ForMember(dest => dest.Guests, opt => opt.MapFrom(src => src.Guests));

        CreateMap<Booking, GetBookingResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
            .ForMember(destinationMember: dest => dest.StartingDate, opt => opt.MapFrom(src => src.StartingDate))
            .ForMember(destinationMember: dest => dest.EndingDate, opt => opt.MapFrom(src => src.EndingDate))
            .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.Room.Id));

        CreateMap<Booking, CreateBookingResponse>();
    }

}
