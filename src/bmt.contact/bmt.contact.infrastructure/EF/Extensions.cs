using bmt.contact.infrastructure.EF.Contexts;
using bmt.contact.infrastructure.EF.Options;
using bmt.shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddMsSql(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<MSSqlOptions>("ConnectionStrings");

            services.AddDbContext<ContactReadDbContext>(ctx => ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<ContactWriteDbContext>(ctx => ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
