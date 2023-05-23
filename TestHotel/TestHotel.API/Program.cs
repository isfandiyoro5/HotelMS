using Microsoft.EntityFrameworkCore;
using Serilog;
using TestHotel.DataAccess.DbConnection;
using Microsoft.Extensions.DependencyInjection;
using TestHotel.Service.DTO.AutoMapper;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.ServiceExtensions;
using TestHotel.Service.Service.IServices;
using TestHotel.Service.Service.Services;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers().AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var config = builder.Configuration.GetSection("ConnectionStrings");
builder.Services.AddDbContext<HotelDbContext>(option => option.UseNpgsql(config["Connect"]));
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
