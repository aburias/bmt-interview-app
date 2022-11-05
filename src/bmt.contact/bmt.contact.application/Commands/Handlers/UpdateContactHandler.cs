using bmt.contact.application.Exceptions;
using bmt.contact.application.Services;
using bmt.contact.domain.Factories;
using bmt.contact.domain.Repositories;
using bmt.shared.abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.application.Commands.Handlers
{
    public class UpdateContactHandler : ICommandHandler<UpdateContact>
    {
        private readonly IContactRepository _repository;
        private readonly IContactFactory _factory;
        private readonly IContactReadService _readService;

        public UpdateContactHandler(IContactReadService readService, IContactFactory factory, IContactRepository repository)
        {
            _readService = readService;
            _factory = factory;
            _repository = repository;
        }

        public async Task HandleAsync(UpdateContact command)
        {
            if (await _readService.ExistsByNameAsync(command.id, command.firstName, command.lastName))
                throw new ContactAlreadyExistException();

            if (await _readService.DuplicateEmailAsync(command.id, command.email))
                throw new EmailExistsException();

            var contact = await _repository.GetByIdAsync(command.id);

            if(contact is null)
                throw new ContactNotFoundException();

            await _repository.UpdateAsync(contact);
        }
    }
}
