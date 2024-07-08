using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUD.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Please Enter Designation Name")]
        public string? Name { get; set; }
    }
}
