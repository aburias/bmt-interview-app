using bmt.contact.domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.ValueObjects
{
    public record CompanyName
    {
        public string Value { get; }

        public CompanyName(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new EmptyCompanyNameException();

            Value = value;
        }

        public static implicit operator string(CompanyName companyName) => companyName.Value;
        public static implicit operator CompanyName(string companyName) => new(companyName);
    }
}
