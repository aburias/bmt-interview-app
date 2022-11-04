using bmt.contact.domain.Entities;
using bmt.contact.infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.infrastructure.EF.Contexts
{
    internal class ContactWriteDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactWriteDbContext(DbContextOptions<ContactWriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bmt");
            base.OnModelCreating(modelBuilder);
        }
    }
}
