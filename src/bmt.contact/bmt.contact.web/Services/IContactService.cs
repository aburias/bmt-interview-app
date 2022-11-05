using bmt.contact.web.Models;

namespace bmt.contact.web.Services
{
    public interface IContactService
    {
        Task CreateAsync(ContactViewModel contact);
        Task<List<ContactViewModel>> GetAllAsync();
    }
}
