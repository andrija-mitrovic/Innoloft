﻿using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore
{
    public static class DependencyInjection
    {
        public static void AddCore(this IServiceCollection service)
        {
            service.ConfigureInjection();
            //service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void ConfigureInjection(this IServiceCollection service)
        {

        }
    }
}