using bmt.contact.web.Models;
using bmt.contact.web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bmt.contact.web.Pages
{
    public class EditContactModel : PageModel
    {

        IContactService _contactService;

        public EditContactModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        [BindProperty]
        public ContactViewModel Contact { get; set; }

        public async Task<IActionResult> OnGet(Guid id)
        {
            Contact = await _contactService.GetByIdAsync(id);

            if(Contact is null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _contactService.UpdateAsync(Contact);
                return RedirectToPage("/Contacts");
            }

            ViewData["Message"] = "There was an error updating contact!";
            return Page();
        }
    }
}
