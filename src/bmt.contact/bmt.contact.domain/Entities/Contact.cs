using bmt.contact.domain.ValueObjects;
using bmt.shared.abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.Entities
{
    public class Contact : AggregateRoot<ContactId>
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public CompanyName CompanyName { get; set; }
        public Mobile Mobile { get; set; }
        public Email Email { get; set; }

        public Contact()
        {

        }
        internal Contact(Guid id, FirstName firstName, LastName lastName, CompanyName companyName, Mobile mobile, Email email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            Email = email;
            Mobile = mobile;
        }
    }
}
