using Microsoft.EntityFrameworkCore;
using Serilog;
using TestHotel.DataAccess.DbConnection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TestHotel.Service.DTO.AutoMapper;
using TestHotel.Service.DTO.RequestDto;
using FluentValidation;

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
builder.Services.AddMvc();
builder.Services.AddScoped<IValidator<BillRequestDto>, BillRequestDtoValidator>();
builder.Services.AddScoped<IValidator<BookingRequestDto>, BookingRequestDtoValidator>();
builder.Services.AddScoped<IValidator<EmployeeRequestDto>, EmployeeRequestDtoValidator>();
builder.Services.AddScoped<IValidator<GuestRequestDto>, GuestRequestDtoValidator>();
builder.Services.AddScoped<IValidator<HotelRequestDto>, HotelRequestDtoValidator>();
builder.Services.AddScoped<IValidator<RoleRequestDto>, RoleRequestDtoValidator>();
builder.Services.AddScoped<IValidator<RoomRequestDto>, RoomRequestDtoValidator>();
builder.Services.AddScoped<IValidator<RoomTypeRequestDto>, RoomTypeRequestDtoValidator>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
