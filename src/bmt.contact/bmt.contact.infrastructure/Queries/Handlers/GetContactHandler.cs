using bmt.contact.application.DTO;
using bmt.contact.application.Queries;
using bmt.contact.domain.Repositories;
using bmt.shared.abstractions.Queries;

namespace bmt.contact.infrastructure.Queries.Handlers
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
