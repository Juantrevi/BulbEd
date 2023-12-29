using BulbEd.Data;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        // Add services to the container.

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseMySql(config.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection")));
        });
        
        return services;
    }
}