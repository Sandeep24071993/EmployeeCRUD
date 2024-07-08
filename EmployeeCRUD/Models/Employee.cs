using EmployeeCRUD.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeCRUD.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Name")]
        [Required(ErrorMessage ="Please Enter Your Name")]
        public string? Name { get; set; }
        [Display(Name = "Age")]
        [Required(ErrorMessage = "Please Enter Your Age")]
        public int? Age { get; set; }
        [Display(Name = "Salary")]
        [Required(ErrorMessage = "Please Enter Your Salary")]
        public int? Salary { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Enter Your Gender")]
        public Genders? Gender { get; set; }
        [Display(Name = "Blood Group")]
        [Required(ErrorMessage = "Please Enter Your Blood Group")]
        public BloodGroups? BloodGroup { get; set; }
        [ForeignKey("Designations")]
        [Required(ErrorMessage = "Designation is required")]
        public int? Designation { get; set; }
        public Designation? Designations { get; set; }
        [ForeignKey("Departments")]
        [Required(ErrorMessage = "Department is required")]
        public int? Department { get; set; }
        public Department? Departments { get; set; }
        public string? Path { get; set; }
        [NotMapped]
        [Display(Name ="Choose Image")]
        public IFormFile? ImagePath { get; set; }
    }
}
