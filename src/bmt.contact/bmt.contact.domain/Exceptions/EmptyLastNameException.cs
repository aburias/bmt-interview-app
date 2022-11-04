using bmt.shared.abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.Exceptions
{
    public class EmptyLastNameException : BmtException
    {
        public EmptyLastNameException() : base("Last name cannot be null or empty!")
        {
        }
    }
}
