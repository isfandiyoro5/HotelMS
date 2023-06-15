using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Repository.Repositories;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.Service.IServices;
using TestHotel.Service.Service.Services;

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
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<HotelDbContext>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
