﻿using bmt.shared.abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.application.Exceptions
{
    public class EmailExistsException : BmtException
    {
        public EmailExistsException() : base("Email already exists!")
        {
        }
    }
}
