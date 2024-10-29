
using BookNest.Api.Middleware;
using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using BookNest.Infrastructure.Interfaces;
using BookNest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BookNest.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Configure Logging by Serilog Libarary:
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Information()
                                .WriteTo.File("Logging/Logging.txt", rollingInterval: RollingInterval.Month)
                                .CreateLogger();


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Inject the dbcontext in program.cs:
            builder.Services.AddDbContext<BookNestDbContext>(options =>
                    options.UseSqlServer(builder.Configuration["ConnectionStrings:MainConnection"])
            );

            //inject automapper in program:
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Inject the repositories:
            builder.Services.AddScoped<IBaseRepository<Book>, BookRepository>();
            builder.Services.AddScoped<IBaseRepository<Author>, AuthorRepository>();
            builder.Services.AddScoped<IBaseRepository<Category>, CategoryRepository>();
            builder.Services.AddScoped<IBaseRepository<Branch>, BranchRepository>();
            builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
            builder.Services.AddScoped<IBaseRepository<Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IBaseRepository<Rating>, RatingRepository>();
            builder.Services.AddScoped<IBaseRepository<Reservation>, ReservationRepository>();

            builder.Services.AddScoped<IRoleRepository, RoleRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseMiddleware<ErrorHandlingMiddleware>();//Inject Exception Handling Middleware

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
