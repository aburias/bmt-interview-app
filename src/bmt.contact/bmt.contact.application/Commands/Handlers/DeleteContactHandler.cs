using bmt.contact.application.Exceptions;
using bmt.contact.application.Services;
using bmt.contact.domain.Repositories;
using bmt.shared.abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.application.Commands.Handlers
{
    public class DeleteContactHandler : ICommandHandler<DeleteContact>
    {
        private readonly IContactRepository _repository;

        public DeleteContactHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeleteContact command)
        {
            var contact = await _repository.GetByIdAsync(command.id);
            if (contact == null)
                throw new ContactNotFoundException();

            await _repository.DeleteAsync(command.id);
        }
    }
}
