﻿using AirsoftClub.Domain.Core.Models;
using AirsoftClub.Domain.Interfaces;
using AirsoftClub.Domain.Interfaces.RepositoryChilds;
using AirsoftClub.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirsoftClub.Infrastructure.Data.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AirsoftClubDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IBaseRepository<Player>, UniversalRepository<Player>>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IClubRepository, ClubRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ITeamRecordRepository, TeamRecordRepository>();
            services.AddScoped<ISoloRecordRepository, SoloRecordRepository>();
            services.AddScoped<IInfoRepository, InfoRepository>();

            return services;
        }
    }
}
