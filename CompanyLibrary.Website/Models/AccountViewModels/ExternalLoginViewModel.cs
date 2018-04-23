using System.ComponentModel.DataAnnotations;

namespace CompanyLibrary.Website.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
