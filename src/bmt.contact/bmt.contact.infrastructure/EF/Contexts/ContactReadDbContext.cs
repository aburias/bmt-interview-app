using bmt.contact.infrastructure.EF.Config;
using bmt.contact.infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.infrastructure.EF.Contexts
{
    internal sealed class ContactReadDbContext : DbContext
    {
        public DbSet<ContactReadModel> Contacts { get; set; }

        public ContactReadDbContext(DbContextOptions<ContactReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bmt");

            var config = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<ContactReadModel>(config);

            base.OnModelCreating(modelBuilder);
        }
    }
}
