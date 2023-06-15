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
            CreateMap<Bill, BillResponseDto>();

            //BookingAutoMapper
            CreateMap<BookingRequestDto, Booking>();
            CreateMap<Booking, BookingResponseDto>();

            //EmployeeAutoMapper
            CreateMap<EmployeeRequestDto, Employee>();
            CreateMap<Employee, EmployeeResponseDto>()
                .ForMember(employeeResponseDto => employeeResponseDto.FullName,
                opt => opt.MapFrom(employee => $"{employee.FirstName} {employee.LastName}"));

            //GuestAutoMapper
            CreateMap<GuestRequestDto, Guest>();
            CreateMap<Guest, GuestResponseDto>()
                .ForMember(guestResponseDto => guestResponseDto.FullName,
                opt => opt.MapFrom(guest => $"{guest.FirstName} {guest.LastName}"));

            //HotelAutoMapper
            CreateMap<HotelRequestDto, Hotel>();
            CreateMap<Hotel, HotelResponseDto>();

            //RoleAutoMapper
            CreateMap<RoleRequestDto, Role>();
            CreateMap<Role, RoleResponseDto>();

            //RoomAutoMapper
            CreateMap<RoomRequestDto, Room>();
            CreateMap<Room, RoomResponseDto>();
        }
    }
}
