using bmt.contact.application.DTO;
using bmt.contact.infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.infrastructure.Queries
{
    internal static class Extensions
    {
        public static ContactDto AsDto(this ContactReadModel readModel)
            => new()
            {
                Id = readModel.Id,
                CompanyName = readModel.CompanyName,
                FirstName = readModel.FirstName,
                LastName = readModel.LastName,
                Mobile = readModel.Mobile,
                Email = readModel.Email
            };
    }
}
