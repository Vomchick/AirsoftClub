using AirsoftClub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirsoftClub.Infrastructure.Data.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<AirsoftClubDbContext>(o =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                o.UseSqlServer(connectionString);
            });

            services.AddSingleton<IDbContextFactory, DbContextFactory>();

            return services;
        }
    }
}
