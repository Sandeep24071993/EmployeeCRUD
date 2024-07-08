using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUD.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Enter Department Name")]
        public string? Name { get; set; }
    }
}
