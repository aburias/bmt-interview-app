using bmt.contact.domain.Factories;
using bmt.shared;
using bmt.shared.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();

            services.AddSingleton<IContactFactory, ContactFactory>();

            return services;
        }
    }
}
