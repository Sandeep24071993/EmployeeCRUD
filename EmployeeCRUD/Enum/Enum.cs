using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUD.Enum
{
    public enum Genders
    {
        Male, Female, Other
    }
    public enum BloodGroups
    {
        [Display(Name = "A+")]
        APos,
        [Display(Name = "A-")]
        ANeg,
        [Display(Name = "B+")]
        BPos,
        [Display(Name = "B-")]
        BNeg,
        [Display(Name = "O+")]
        OPos,
        [Display(Name = "O-")]
        ONeg,
        [Display(Name = "AB+")]
        ABPos,
        [Display(Name = "AB-")]
        ABNeg
    }
}
