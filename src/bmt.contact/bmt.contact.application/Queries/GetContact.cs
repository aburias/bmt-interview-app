using bmt.contact.application.DTO;
using bmt.shared.abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.application.Queries
{
    public class GetContact : IQuery<ContactDto>
    {
        public Guid id { get; set; }
    }
}
