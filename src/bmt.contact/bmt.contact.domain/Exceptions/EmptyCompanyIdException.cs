using bmt.shared.abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.Exceptions
{
    public class EmptyCompanyIdException : BmtException
    {
        public EmptyCompanyIdException() : base("Company ID cannot be empty!")
        {
        }
    }
}
