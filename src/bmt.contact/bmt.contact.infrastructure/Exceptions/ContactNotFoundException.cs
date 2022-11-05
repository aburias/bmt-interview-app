using bmt.shared.abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.infrastructure.Exceptions
{
    internal class ContactNotFoundException : BmtException
    {
        public ContactNotFoundException() : base("Contact was not found!")
        {
        }
    }
}
