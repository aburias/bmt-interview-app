using bmt.contact.domain.Entities;
using bmt.contact.domain.Repositories;
using bmt.contact.domain.ValueObjects;
using bmt.contact.infrastructure.EF.Contexts;
using bmt.contact.infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.infrastructure.EF.Repositories
{
    internal sealed class MSSqlContactRepository : IContactRepository
    {
        private readonly DbSet<Contact> _contacts;
        private readonly ContactWriteDbContext _writeDbContext;

        public MSSqlContactRepository(ContactWriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _contacts = writeDbContext.Contacts;
        }

        public async Task<Contact> CreateAsync(Contact entity)
        {
            await _contacts.AddAsync(entity);
            await _writeDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(ContactId id)
        {
            var contact = await _contacts.SingleOrDefaultAsync(c => c.Id == id);
            if(contact is null)
                throw new ContactNotFoundException();

            _contacts.Remove(contact);
            return await _writeDbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Contact>> GetAllAsync() => await _contacts.ToListAsync();

        public async Task<Contact> GetByIdAsync(ContactId id) => await _contacts.SingleOrDefaultAsync(c => c.Id == id);

        public async Task<Contact> UpdateAsync(Contact entity)
        {
            _contacts.Update(entity);
            await _writeDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
