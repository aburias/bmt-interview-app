using bmt.contact.infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<ContactReadModel>
    {
        public void Configure(EntityTypeBuilder<ContactReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Contacts");
        }
    }
}
