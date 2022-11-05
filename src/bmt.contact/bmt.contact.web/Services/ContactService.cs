using bmt.contact.web.Helpers;
using bmt.contact.web.Models;

namespace bmt.contact.web.Services
{
    public class ContactService : IContactService
    {
        private readonly IConfiguration _config;
        private static string _baseUrl;
        private static string _endpoint;

        public ContactService(IConfiguration config)
        {
            _config = config;
            _baseUrl = _config["ApiUrls:ContactsApiUrl"];
            _endpoint = "contact";

        }

        public async Task CreateAsync(ContactViewModel contact)
        {
            var results = await ApiHelpers.ExecuteApiAsync<dynamic>(_baseUrl, _endpoint, RestSharp.Method.Post, null, contact);
        }

        public async Task<List<ContactViewModel>> GetAllAsync()
        {
            var results = await ApiHelpers.ExecuteApiAsync<List<ContactViewModel>>(_baseUrl, _endpoint, RestSharp.Method.Get, null, null);
            return results ?? new List<ContactViewModel>();
        }

        public async Task<ContactViewModel> GetByIdAsync(Guid id)
        {
            var results = await ApiHelpers.ExecuteApiAsync<ContactViewModel>(_baseUrl, $"{_endpoint}/{id}", RestSharp.Method.Get, null, null);
            return results ?? new ContactViewModel();
        }

        public async Task UpdateAsync(ContactViewModel contact)
        {
            var results = await ApiHelpers.ExecuteApiAsync<dynamic>(_baseUrl, _endpoint, RestSharp.Method.Put, null, contact);
        }

        public async Task DeleteAsync(Guid contactId)
        {
            var results = await ApiHelpers.ExecuteApiAsync<dynamic>(_baseUrl, $"{_endpoint}/{contactId}", RestSharp.Method.Delete, null, null);
        }
    }
}
