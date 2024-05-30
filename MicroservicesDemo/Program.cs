using MicroservicesDemo.Models;
using MicroservicesDemo.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<CategoryContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("ConstrCategory")));
            builder.Services.AddDbContext<ProductContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("ConstrProduct")));

            builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
            builder.Services.AddTransient<IProductRepo, ProductRepo>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
