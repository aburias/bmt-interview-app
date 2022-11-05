using bmt.contact.application.DTO;
using bmt.contact.application.Queries;
using bmt.contact.domain.Repositories;
using bmt.contact.infrastructure.EF.Contexts;
using bmt.contact.infrastructure.EF.Models;
using bmt.shared.abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace bmt.contact.infrastructure.Queries.Handlers
{
    internal sealed class GetContactHandler : IQueryHandler<GetContact, ContactDto>
    {
        private readonly DbSet<ContactReadModel> _contacts;

        public GetContactHandler(ContactReadDbContext context) => _contacts = context.Contacts;

        public async Task<ContactDto> HandleAsync(GetContact query) 
            => await _contacts.Where(c => c.Id == query.id)
            .Select(c => c.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
}
