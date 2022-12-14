using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Person.Application.Interfaces;
using Person.Infrastructure.Context;
using Person.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonDbContext, PersonDbContext>();


            services.AddDbContext<PersonDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Persondb")));

            return services;


        }
    }
}
