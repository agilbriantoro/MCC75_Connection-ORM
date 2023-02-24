using System.ComponentModel.DataAnnotations;

namespace MCC75_NET.ViewModels
{
    public class AccountEmployeeVM
    {
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string EmployeeEmail { get; set; }
        public string Password { get; set; }

    }
}
