using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.shared.abstractions.Exceptions
{
    public abstract class BmtException : Exception
    {
        protected BmtException(string message) : base(message)
        {

        }
    }
}
