﻿using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            service.ConfigureDatabase(config);
            service.ConfigureInjection();
        }

        private static void ConfigureDatabase(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection")));
        }

        private static void ConfigureInjection(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
