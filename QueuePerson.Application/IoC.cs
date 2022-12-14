﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QueuePerson.Application.QueuePerson.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QueuePerson.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            services.AddTransient<IQueuePersonHandler, QueuePersonHandler>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
