using System.ComponentModel.DataAnnotations;

namespace MCC75_NET.ViewModels
{
    public class AccountRoleVM
    {
        public int Id { get; set; }
        public string AccountNIK { get; set; }

        [Display(Name = "Role Name")]
        public int RoleId { get; set; }
    }
}
