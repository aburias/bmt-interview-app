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
    public class CreateContactHandler : ICommandHandler<CreateContact>
    {
        private readonly IContactRepository _repository;
        private readonly IContactFactory _factory;
        private readonly IContactReadService _readService;

        public CreateContactHandler(IContactReadService readService, IContactFactory factory, IContactRepository repository)
        {
            _readService = readService;
            _factory = factory;
            _repository = repository;
        }

        public async Task HandleAsync(CreateContact command)
        {
            if(await _readService.ExistsByNameAsync(command.id, command.firstName, command.lastName))
                throw new ContactAlreadyExistException();

            if(await _readService.DuplicateEmailAsync(command.id, command.email))
                throw new EmailExistsException();

            var contact = _factory.Create(command.id, command.firstName, command.lastName, command.companyName, command.mobile, command.email);

            await _repository.CreateAsync(contact);
        }
    }
}
