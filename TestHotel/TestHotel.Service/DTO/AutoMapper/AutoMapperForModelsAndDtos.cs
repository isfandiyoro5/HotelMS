using AutoMapper;
using TestHotel.DataAccess.Model;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;

namespace TestHotel.Service.DTO.AutoMapper
{
    public class AutoMapperForModelsAndDtos : Profile
    {
        public AutoMapperForModelsAndDtos()
        {
            //BillAutoMapper
            CreateMap<BillRequestDto, Bill>();
            CreateMap<Bill, BillResponseDto>()
                .ForMember(billResponseDto => billResponseDto.GuestFullName,
                opt => opt.MapFrom(bill => $"{bill.Guest.FirstName} {bill.Guest.LastName}"));

            //BookingAutoMapper
            CreateMap<BookingRequestDto, Booking>();
            CreateMap<Booking, BookingResponseDto>()
                .ForMember(bookingResponseDto => bookingResponseDto.HotelName,
                opt => opt.MapFrom(booking => booking.Hotel.HotelName))
                .ForMember(bookingResponseDto => bookingResponseDto.GuestFullName,
                opt => opt.MapFrom(booking => $"{booking.Guest.FirstName} {booking.Guest.LastName}"))
                .ForMember(bookingRequestDto => bookingRequestDto.RoomsNumber,
                opt => opt.MapFrom(booking => booking.Rooms.Select(room => room.RoomNumber).ToList()));

            //EmployeeAutoMapper
            CreateMap<EmployeeRequestDto, Employee>();
            CreateMap<Employee, EmployeeResponseDto>()
                .ForMember(employeeResponseDto => employeeResponseDto.FullName,
                opt => opt.MapFrom(employee => $"{employee.FirstName} {employee.LastName}"))
                .ForMember(employeeRequestDto => employeeRequestDto.HotelName,
                opt => opt.MapFrom(employee => employee.Hotel.HotelName))
                .ForMember(employeeResponseDto => employeeResponseDto.RoleTitle,
                opt => opt.MapFrom(employee => employee.Role.RoleTitle));

            //GuestAutoMapper
            CreateMap<GuestRequestDto, Guest>();
            CreateMap<Guest, GuestResponseDto>()
                .ForMember(guestResponseDto => guestResponseDto.FullName,
                opt => opt.MapFrom(guest => $"{guest.FirstName} {guest.LastName}"))
                .ForMember(guestResponseDto => guestResponseDto.Address,
                opt => opt.MapFrom(guest => $"{guest.Street} {guest.City} {guest.Country}"));

            //HotelAutoMapper
            CreateMap<HotelRequestDto, Hotel>();
            CreateMap<Hotel, HotelResponseDto>()
                .ForMember(hotelResponseDto => hotelResponseDto.Address,
                opt => opt.MapFrom(hotel => $"{hotel.Street} {hotel.City} {hotel.Country}"));

            //RoleAutoMapper
            CreateMap<RoleRequestDto, Role>();
            CreateMap<Role, RoleResponseDto>();

            //RoomAutoMapper
            CreateMap<RoomRequestDto, Room>();
            CreateMap<Room, RoomResponseDto>()
                .ForMember(roomRequestDto => roomRequestDto.HotelName,
                opt => opt.MapFrom(room => room.Hotel.HotelName));
        }
    }
}
