using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi
{
    public class Program
    {
        public static void Main(string[] args)
           
        {
            const string HotelName = "myHotel";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddTransient<IHotelComponent, HotelComponent>();
            builder.Services.AddCors((options) =>
            {
                options.AddPolicy(HotelName, options =>
                {
                    options.AllowAnyHeader();
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();
            app.UseCors(HotelName);

            app.MapGet("/Hotel", ([FromServices] IHotelComponent com) =>
            {
                return com.GetMenu();
            });
            app.MapPost("/Hotel", (MenuClass menu, IHotelComponent com) =>
            {
                com.AddItems(menu);
                return "menu Added Successfully";
            });



            app.Run();
        }
    }
}