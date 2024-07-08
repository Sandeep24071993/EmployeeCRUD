using EmployeeCRUD.Models;

namespace EmployeeCRUD.DepartmentService
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartment();
        Task<int> AddDepartment(Department data);
        Task<Department> EditGetId(int id);
        Task<bool> UpdateDepartment(Department data);
        Task<bool> DeleteRecard(int id);
    }
}
