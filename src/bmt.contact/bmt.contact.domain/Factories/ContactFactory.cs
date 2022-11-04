using bmt.contact.domain.Entities;
using bmt.contact.domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.Factories
{
    public sealed class ContactFactory : IContactFactory
    {
        public Contact Create(ContactId id, FirstName firstName, LastName lastName, CompanyName companyName, Mobile mobile, Email email) 
            => new Contact(id, firstName, lastName, companyName, mobile, email);
    }
}
