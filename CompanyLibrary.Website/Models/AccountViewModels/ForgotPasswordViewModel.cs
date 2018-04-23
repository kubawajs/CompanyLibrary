using System.ComponentModel.DataAnnotations;

namespace CompanyLibrary.Website.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
