using bmt.shared.abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.application.Commands
{
    public record DeleteContact(Guid id) : ICommand;
}
