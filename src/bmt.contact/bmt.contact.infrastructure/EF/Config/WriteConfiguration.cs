using bmt.contact.domain.Entities;
using bmt.contact.domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);

            var firstNameConverter = new ValueConverter<FirstName, string>(fn => fn.Value, fn => new FirstName(fn));
            var lastNameConverter = new ValueConverter<LastName, string>(fn => fn.Value, fn => new LastName(fn));
            var companyNameConverter = new ValueConverter<CompanyName, string>(fn => fn.Value, fn => new CompanyName(fn));
            var mobileConverter = new ValueConverter<Mobile, string>(fn => fn.Value, fn => new Mobile(fn));
            var emailConverter = new ValueConverter<Email, string>(fn => fn.Value, fn => new Email(fn));

            builder
                .Property(c => c.Id)
                .HasConversion(id => id.Value, id => new ContactId(id));

            builder
                .Property(c => c.FirstName)
                .HasConversion(firstNameConverter)
                .HasColumnName("FirstName");

            builder
                .Property(c => c.LastName)
                .HasConversion(lastNameConverter)
                .HasColumnName("LastName");

            builder
                .Property(c => c.CompanyName)
                .HasConversion(companyNameConverter)
                .HasColumnName("CompanyName");

            builder
                .Property(c => c.Mobile)
                .HasConversion(mobileConverter)
                .HasColumnName("Mobile");

            builder
                .Property(c => c.Email)
                .HasConversion(emailConverter)
                .HasColumnName("Email");

            builder.ToTable("Contacts");
        }
    }
}
