//using Microsoft.EntityFrameworkCore;
//using Fotovoltaico.Infra.Data.Context;
//using Fotovoltaico.Domain.Mappers;
//using AspNetCore.Scalar;
//using Fotovoltaico.Domain.Interfaces.Services;
//using Fotovoltaico.Domain.Services;
//using Fotovoltaico.Domain.Interfaces.Repositories;
//using Fotovoltaico.Infra.Data.Repositories;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddAutoMapper(typeof(AutoMapperSetup));
//builder.Configuration.AddJsonFile("appsettings.json");

//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 24)), options => options.EnableRetryOnFailure()));

//var app = builder.Build();

//app.UseScalar(options =>
//{
//    options.UseTheme(Theme.Default);
//    options.RoutePrefix = "api-docs";
//});

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

namespace Fotovoltaico.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
