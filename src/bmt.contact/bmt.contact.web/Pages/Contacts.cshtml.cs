using bmt.contact.web.Models;
using bmt.contact.web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bmt.contact.web.Pages
{
    public class ContactsModel : PageModel
    {
        private readonly IContactService _contactService;

        public List<ContactViewModel> Contacts { get; set; }

        public ContactsModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> OnGet()
        {
            Contacts = await _contactService.GetAllAsync();
            
            return Page();
        }
    }
}
