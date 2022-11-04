using bmt.contact.application.DTO;
using bmt.contact.domain.Repositories;
using bmt.shared.abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.application.Queries.Handlers
{
    public class GetContactHandler : IQueryHandler<GetContact, ContactDto>
    {
        private readonly IContactRepository _repository;

        public GetContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContactDto> HandleAsync(GetContact query)
        {
            throw new NotImplementedException();
        }
    }
}
