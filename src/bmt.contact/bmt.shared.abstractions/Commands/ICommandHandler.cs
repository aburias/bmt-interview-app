using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.shared.abstractions.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand: class, ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
