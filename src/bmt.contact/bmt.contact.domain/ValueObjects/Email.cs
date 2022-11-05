using bmt.contact.domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bmt.contact.domain.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if(!ValidEmail(value))
                throw new InvalidEmailAddressException();

            Value = value;
        }

        public static implicit operator string(Email email) => email.Value;
        public static implicit operator Email(string email) => new(email);

        private bool ValidEmail(string value)
        {
            if(string.IsNullOrEmpty(value))
                return false;

            string email = value;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
                return false;

            // Additional email validators here

            return true;
        }
    }
}
