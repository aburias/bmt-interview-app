using bmt.contact.application.DTO;
using bmt.contact.application.Queries;
using bmt.contact.infrastructure.EF.Contexts;
using bmt.contact.infrastructure.EF.Models;
using bmt.shared.abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace bmt.contact.infrastructure.Queries.Handlers
{
    internal sealed class SearchContactHandler : IQueryHandler<SearchContact, IEnumerable<ContactDto>>
    {
        private readonly DbSet<ContactReadModel> _contacts;

        public SearchContactHandler(ContactReadDbContext context) => _contacts = context.Contacts;

        public async Task<IEnumerable<ContactDto>> HandleAsync(SearchContact query)
        {
            var dbQuery = _contacts
                .AsQueryable();

            if(query.SearchPhrase is not null)
            {
                dbQuery = dbQuery.Where(c => 
                    Microsoft.EntityFrameworkCore.EF.Functions.Like(c.FirstName, $"%{query.SearchPhrase}%")
                ||  Microsoft.EntityFrameworkCore.EF.Functions.Like(c.LastName, $"%{query.SearchPhrase}%")
                ||  Microsoft.EntityFrameworkCore.EF.Functions.Like(c.CompanyName, $"%{query.SearchPhrase}%")
                ||  Microsoft.EntityFrameworkCore.EF.Functions.Like(c.Mobile, $"%{query.SearchPhrase}%")
                ||  Microsoft.EntityFrameworkCore.EF.Functions.Like(c.Email, $"%{query.SearchPhrase}%")
                );
            }

            return await dbQuery
                .Select(c => c.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
