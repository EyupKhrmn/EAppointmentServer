using EAppointmentServer.Application.Services;
using EAppointmentServer.Domain.Entities;
using EAppointmentServer.Domain.Repositories;
using EAppointmentServer.Infrastructure.Context;
using EAppointmentServer.Infrastructure.Repositories;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace EAppointmentServer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddIdentity<AppUser, AppRole>(action =>
        {
            action.Password.RequiredLength = 1;
            action.Password.RequireUppercase = false;
            action.Password.RequireLowercase = false;
            action.Password.RequireNonAlphanumeric = false;
            action.Password.RequireDigit = false;

        }).AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IUnitOfWork>(_ => _.GetRequiredService<ApplicationDbContext>());
        
        //scrutor kütüphanesi DI servislerini otomatik olarak ekleyebiliriz.
        services.Scan(action =>
        {
            action
                .FromAssemblies(typeof(DependencyInjection).Assembly)
                .AddClasses(publicOnly: false) // sadece public olan class'ları değil tüm classları ekle
                .UsingRegistrationStrategy(RegistrationStrategy.Skip) // zaten eklenmiş olanları yeniden ekleme skip et
                .AsImplementedInterfaces() // interface'lerin implement edildiği class'ları ekle
                .WithScopedLifetime(); // scoped lifetime ile ekle  
        });
        
        // Normalde bunlara gerek yok
        // services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        // services.AddScoped<IDoctorRepository, DoctorRepository>();
        // services.AddScoped<IPatientRepository, PatientRepository>();
        // services.AddScoped<IJwtProvider, IJwtProvider>();
        
        
        return services;
    } 
}