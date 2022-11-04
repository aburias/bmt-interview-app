using bmt.contact.application.DTO;
using bmt.shared.abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.application.Queries.Handlers
{
    public class SearchContactHandler : IQueryHandler<SearchContact, IEnumerable<ContactDto>>
    {
        // TODO: You are here...5:10:00
        public async Task<IEnumerable<ContactDto>> HandleAsync(SearchContact query)
        {
            throw new NotImplementedException();
        }
    }
}
