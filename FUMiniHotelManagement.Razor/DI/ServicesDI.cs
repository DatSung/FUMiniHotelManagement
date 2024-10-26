using FUMiniHotelManagement.Service.Implements;
using FUMiniHotelManagement.Service.Interfaces;

namespace FUMiniHotelManagement.Razor.DI
{
    public static class ServicesDI
    {
        public static WebApplicationBuilder AppServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IBookingDetailService, BookingDetailService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
            builder.Services.AddScoped<IUserService, UserService>();

            return builder;
        }
    }
}
