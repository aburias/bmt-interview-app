using bmt.contact.web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bmt.contact.web.Pages
{
    public class DeleteContactModel : PageModel
    {
        IContactService _service;

        public DeleteContactModel(IContactService service)
        {
            _service = service;
        }

        [BindProperty]
        public Guid ContactId { get; set; }
        public void OnGet(Guid id)
        {
            ContactId = id;
        }

        public async Task<IActionResult> OnPost()
        {
            await _service.DeleteAsync(ContactId);
            return RedirectToPage("/Contacts");
        }
    }
}
