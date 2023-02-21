using System.ComponentModel.DataAnnotations;

namespace MCC75_NET.ViewModels
{
    public class EducationVM
    {
        public int Id { get; set; }
        public string Major { get; set; }

        [MaxLength(2), MinLength(2, ErrorMessage = "Example of Degree Input: S1/D3")]
        [Required(ErrorMessage = "Example of Degree Input: S1/D3")]
        public string Degree { get; set; }

        [Range(0, 4, ErrorMessage = "Contoh Inputan ex: 3.9")]
        public float GPA { get; set; }

        [Display(Name = "University Name")]
        public string UniversityName { get; set; }
    }
}
