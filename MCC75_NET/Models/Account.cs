using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC75_NET.Models
{
    [Table("tb_m_account")]
    public class Account
    {
        [Key, Column("employee_nik", TypeName ="nchar(5)")]
        public string EmployeesNik { get; set; }
        [Required, Column("password"), MaxLength(255)]
        public string Password { get; set;}

        // Cardinality
        public ICollection<AccountRole>? accountRoles { get; set; } 
        public Employee? employee { get; set; }
        public object EmployeeNIK { get; set; }
    }
}
