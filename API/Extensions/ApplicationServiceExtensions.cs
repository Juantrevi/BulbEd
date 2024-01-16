using System.Configuration;
using BulbEd.Data;
using BulbEd.Entities;
using BulbEd.Helpers;
using BulbEd.Interfaces;
using BulbEd.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BulbEd.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp",
                builder => builder.WithOrigins("http://localhost:4300")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });

        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseMySql(config.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection")));
        });

    var mailgunSettings = config.GetSection("Mailgun");
    services
        .AddFluentEmail("no-reply@bulbed.com")
        .AddMailGunSender(mailgunSettings["Domain"],
            mailgunSettings["ApiKey"]);


        // Add services to the container.
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<LogUserActivity>();
        services.AddScoped<IContactDetailRepository, ContactDetailRepository>();
        services.AddScoped<ITokenBlacklistService, TokenBlacklistService>();
        services.AddScoped<IInstitutionRepository, InstitutionRepository>();
        services.AddScoped<IInstituteService, InstitutionService>();
        services.AddScoped<IClassScheduleRepository, ClassScheduleRepository>();
        services.AddScoped<IClassScheduleService, ClassScheduleService>();
        services.AddScoped<IEmailSender, EmailSenderService>();
        //services.AddIdentity<AppUser, AppRole>()
          //  .AddEntityFrameworkStores<DataContext>()
            //.AddDefaultTokenProviders();
        

        return services;
    }
    
}