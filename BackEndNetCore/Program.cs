
using DataAccess.NetCore.Data;
using DataAccess.NetCore.IServices;
using DataAccess.NetCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace BackEndNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationBEDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IAccountServices, AccountServices>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IRoomService, RoomService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseMiddleware<MyCustomMiddleware>();
            app.UseMyMiddleware();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
