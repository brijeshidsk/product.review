using Microsoft.EntityFrameworkCore;
using RestFullWebAPI.Models;
using RestFullWebAPI.Repositories;
using RestFullWebAPI.Services;

namespace RestFullWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Extract the connection String from config file
            var connectionString = builder.Configuration.GetConnectionString("EComDBConnection");
            builder.Services.AddDbContext<EComDBContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IUserDataRepository<User>, UserRepository>();
            builder.Services.AddScoped<IDataRepository<Category>, CategoryRepository>();
            builder.Services.AddScoped<IProductDataRepository<Product>, ProductRepository>();

            builder.Services.AddScoped<IUserDataService<User>, UserService>();
            builder.Services.AddScoped<IProductDataService<Product>, ProductService>();
            builder.Services.AddScoped<IDataService<Category>, CategoryService>();
            

            var clientName = "ecomapp";
            builder.Services.AddCors(p => p.AddPolicy(name: clientName, policy =>
            {
                policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));


            var app = builder.Build();
            app.UseCors(clientName);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}