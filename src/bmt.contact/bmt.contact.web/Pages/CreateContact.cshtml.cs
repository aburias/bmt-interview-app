using bmt.contact.web.Models;
using bmt.contact.web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bmt.contact.web.Pages
{
    public class CreateContactModel : PageModel
    {
        IContactService _contactService;

        public CreateContactModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        [BindProperty]
        public ContactViewModel Contact { get; set; }
        public void OnGet()
        {
            ViewData["Message"] = "";
            Contact = new ContactViewModel()
            {
                Id = Guid.NewGuid()
            };
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _contactService.CreateAsync(Contact);
                return RedirectToPage("/Contacts");
            }

            ViewData["Message"] = "There was an error creating new contact!";
            return Page();
        }
    }
}
