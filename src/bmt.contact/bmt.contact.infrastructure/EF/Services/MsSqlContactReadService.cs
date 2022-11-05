using bmt.contact.application.Services;
using bmt.contact.domain.ValueObjects;
using bmt.contact.infrastructure.EF.Contexts;
using bmt.contact.infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.infrastructure.EF.Services
{
    internal sealed class MsSqlContactReadService : IContactReadService
    {
        private readonly DbSet<ContactReadModel> _contacts;
        private readonly ContactReadDbContext _readDbContext;

        public MsSqlContactReadService(ContactReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
            _contacts = _readDbContext.Contacts;
        }

        public async Task<bool> DuplicateEmailAsync(Guid id, string email) 
            => await _contacts.AnyAsync(c => c.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)
            && c.Id != id);

        public async Task<bool> ExistsByNameAsync(Guid id, string firstName, string lastName)
            => await _contacts.AnyAsync(c => c.FirstName.Equals(firstName, StringComparison.InvariantCultureIgnoreCase)
            && c.LastName.Equals(lastName, StringComparison.InvariantCultureIgnoreCase)
            && c.Id != id);
    }
}