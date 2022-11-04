using bmt.contact.domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.ValueObjects
{
    public record ContactId
    {
        public Guid Value { get; }

        public ContactId(Guid value)
        {
            if(value == Guid.Empty)
                throw new EmptyCompanyIdException();

            Value  = value;
        }

        public static implicit operator Guid(ContactId id) => id.Value;
        public static implicit operator ContactId(Guid id) => new(id);
    }
}
