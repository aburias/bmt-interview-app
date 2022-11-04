using bmt.shared.abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.application.Commands
{
    public record UpdateContact(Guid id, string firstName, string lastName, string companyName, string email) : ICommand;
}
