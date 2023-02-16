using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace MCC75_NET.Models
{
    [Table("tb_m_universities")]
    public class University
    {
        
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, Column("name"),MaxLength(100)]
        public string Name { get; set; }



        // Cardinality

        public ICollection<Education> Educations{ get; set; }  

    }
}
