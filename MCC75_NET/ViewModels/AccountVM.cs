using System.ComponentModel.DataAnnotations;

namespace MCC75_NET.ViewModels
{
    public class AccountVM
    {
        public string EmployeeNIK { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
