using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Queue.Application.Interfaces;
using Queue.Infrastructure.Context;
using Queue.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddTransient<IQueueService, QueueService>();
            services.AddTransient<IQueueDbContext, QueueDbContext>();


            services.AddDbContext<QueueDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Queuedb")));

            return services;


        }
    }
}
