using System.ComponentModel.DataAnnotations;

namespace MCC75_NET.ViewModels
{
    public class EmployeeVM
    {
        public string NIK { get; set; }

        [Range(3, 50, ErrorMessage = "Nama tidak boleh kurang dari 3 dan lebih dari 50 karakter")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        public GenderEnum Gender { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime HireDate { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "ex : admin@gmail.com")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }

    public enum GenderEnum
    {
        Male,
        Female
    }
}
