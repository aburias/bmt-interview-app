using bmt.contact.domain.Entities;
using bmt.contact.domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.Repositories
{
    public interface IContactRepository : IRepository<Contact, ContactId>
    {
    }
}
