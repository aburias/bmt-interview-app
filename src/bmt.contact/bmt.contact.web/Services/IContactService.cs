using bmt.contact.web.Models;

namespace bmt.contact.web.Services
{
    public interface IContactService
    {
        Task CreateAsync(ContactViewModel contact);
        Task DeleteAsync(Guid contactId);
        Task<List<ContactViewModel>> GetAllAsync();
        Task<ContactViewModel> GetByIdAsync(Guid id);
        Task UpdateAsync(ContactViewModel contact);
    }
}
