using bmt.contact.domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.ValueObjects
{
    public record Mobile
    {
        public string Value { get; }
        public Mobile(string value)
        {
            if(!ValidMobileNumber(value))
                throw new InvalidMobileNumberException();

            Value = value;
        }

        public static implicit operator string(Mobile mobile) => mobile.Value;
        public static implicit operator Mobile(string mobile) => new(mobile);

        private bool ValidMobileNumber(string value)
        {
            if(string.IsNullOrEmpty(value))
                return false;

            // Maybe add more validations here...

            return true;
        }
    }
}
