using bmt.contact.application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.application.Services
{
    public interface IContactReadService
    {
        Task<bool> ExistsByNameAsync(Guid id, string firstName, string lastName);

        Task<bool> DuplicateEmailAsync(Guid id, string email);
    }
}
