using bmt.shared.abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.Exceptions
{
    public class EmptyCompanyNameException : BmtException
    {
        public EmptyCompanyNameException() : base("Company Name cannot be null or empty!")
        {
        }
    }
}
