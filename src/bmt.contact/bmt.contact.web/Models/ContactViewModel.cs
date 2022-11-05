using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bmt.contact.web.Models
{
    public class ContactViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
