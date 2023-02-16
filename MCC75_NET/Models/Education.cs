using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC75_NET.Models
{
    [Table("tb_m_educations")]
    public class Education
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, Column("major"), MaxLength(100)]
        public string Major { get; set; }
        [Required, Column("degree"), MaxLength(2)]
        public string degree { get; set; }
        [Required, Column("gpa")]
        public float Gpa { get; set; }
        [Required, Column("university_id"), MaxLength(11)]
        public int UniversityId { get; set; }

        //Relasi dan Cardinality
        [ForeignKey(nameof(UniversityId))]

        public University? university { get; set; }  
        public ICollection <Profilling>? profillings { get; set; }
    }
}
