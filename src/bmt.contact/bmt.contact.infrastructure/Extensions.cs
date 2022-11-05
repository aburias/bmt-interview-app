using bmt.contact.domain.Factories;
using bmt.contact.infrastructure.EF;
using bmt.contact.infrastructure.EF.Options;
using bmt.shared.Options;
using bmt.shared.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMsSql(configuration);
            services.AddQueries();

            return services;
        }
    }
}
