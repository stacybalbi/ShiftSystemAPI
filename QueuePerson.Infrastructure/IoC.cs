using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueuePerson.Application.Interfaces;
using QueuePerson.Infrastructure.Context;
using QueuePerson.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePerson.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IQueuePersonService, QueuePersonService>();
            services.AddTransient<IQueuePersonDbContext, QueuePersonDbContext>();


            services.AddDbContext<QueuePersonDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("QueuePersondb")));

            return services;


        }
    }
}
