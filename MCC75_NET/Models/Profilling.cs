using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace MCC75_NET.Models
{
    [Table("tb_tr_profilings")]
    public class Profilling
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, Column("employee_nik"), MaxLength(5)]
        public string EmployeeNik { get; set; }
        [Required, Column("education_id")]
        public int EducationsId { get; set; }

        //Relasi dan Cardinality
        [ForeignKey(nameof(EducationsId))]
        public Education? Education { get; set; }
        [ForeignKey(nameof(EmployeeNik))]
        public Employee? Employee { get; set; }  

    }
}
