using System.ComponentModel.DataAnnotations;

namespace MCC75_NET.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "E-Mail")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
