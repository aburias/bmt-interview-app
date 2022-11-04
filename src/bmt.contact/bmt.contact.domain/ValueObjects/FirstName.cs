using bmt.contact.domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.ValueObjects
{
    public record FirstName
    {
        public string Value { get; }

        public FirstName(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new EmptyFirstNameException();

            Value = value;
        }

        public static implicit operator string(FirstName firstName) => firstName.Value;
        public static implicit operator FirstName(string firstName) => new(firstName);
    }
}
