using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestHotel.Service.DTO.AutoMapper;
using TestHotel.Service.DTO.RequestDto;
using FluentValidation;
using AutoMapper;

namespace TestHotel.Service.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc();
            services.AddScoped<IValidator<BillRequestDto>, BillRequestDtoValidator>();
            services.AddScoped<IValidator<BookingRequestDto>, BookingRequestDtoValidator>();
            services.AddScoped<IValidator<EmployeeRequestDto>, EmployeeRequestDtoValidator>();
            services.AddScoped<IValidator<GuestRequestDto>, GuestRequestDtoValidator>();
            services.AddScoped<IValidator<HotelRequestDto>, HotelRequestDtoValidator>();
            services.AddScoped<IValidator<RoleRequestDto>, RoleRequestDtoValidator>();
            services.AddScoped<IValidator<RoomRequestDto>, RoomRequestDtoValidator>();
            services.AddScoped<IValidator<RoomTypeRequestDto>, RoomTypeRequestDtoValidator>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
