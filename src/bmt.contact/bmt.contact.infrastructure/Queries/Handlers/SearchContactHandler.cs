using bmt.contact.application.DTO;
using bmt.contact.application.Queries;
using bmt.shared.abstractions.Queries;

namespace bmt.contact.infrastructure.Queries.Handlers
{
    public class SearchContactHandler : IQueryHandler<SearchContact, IEnumerable<ContactDto>>
    {
        public async Task<IEnumerable<ContactDto>> HandleAsync(SearchContact query)
        {
            throw new NotImplementedException();
        }
    }
}
