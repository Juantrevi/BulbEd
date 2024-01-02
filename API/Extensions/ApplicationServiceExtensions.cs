﻿using BulbEd.Data;
using BulbEd.Entities;
using BulbEd.Helpers;
using BulbEd.Interfaces;
using BulbEd.Services;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {

        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseMySql(config.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection")));
        });

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
        services.AddScoped<IInstituteService, InstituteService>();
        

        
        
        

        return services;
    }
}