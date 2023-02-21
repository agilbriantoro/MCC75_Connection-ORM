using System.ComponentModel.DataAnnotations;

namespace MCC75_NET.ViewModels
{
    public class EducationVM
    {
        public int Id { get; set; }
        public string Major { get; set; }

        [Range(2, 2, ErrorMessage = "Contoh Inputan ex: S1")]
        public string Degree { get; set; }

        [Range(0, 4, ErrorMessage = "Contoh Inputan ex: 3.9")]
        public float GPA { get; set; }

        [Display(Name = "University Name")]
        public string UniversityName { get; set; }
    }
}
