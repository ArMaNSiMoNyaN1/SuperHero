using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Services.Implementations;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ServiceRegistration));
            services.AddScoped<IFootballPlayerService, FootballPlayerService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<ICartoonHeroService, CartoonHeroService>();
            services.AddScoped<ISuperHeroService, SuperHeroService>();
            services.AddScoped<IPlaneService, PlaneService>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IExcavatorService, ExcavatorService>();
            return services;
        }

        public static IServiceCollection MigrateDatabase(this IServiceCollection services)
        {
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.Migrate();
            }

            return services;
        }
    }
}