using System.ComponentModel.DataAnnotations;

namespace MCC75_NET.ViewModels
{
    public class UniversityVM
    {
        public int Id { get; set; }

        [Display(Name = "University Name")]
        public string Name { get; set; }
    }
}
