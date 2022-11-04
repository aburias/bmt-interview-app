using bmt.contact.domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.Entities
{
    public class Contact
    {
        public Guid Id { get; private set; }
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public CompanyName CompanyName { get; set; }
        public Email Email { get; set; }

        internal Contact(Guid id, FirstName firstName, LastName lastName, CompanyName companyName, Email email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            Email = email;
        }
    }
}
