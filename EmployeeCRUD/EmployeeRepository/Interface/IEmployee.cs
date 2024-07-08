using EmployeeCRUD.Models;

namespace EmployeeCRUD.EmployeeRepository.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetEmployee();
        Task<int> AddEmployee(Employee data);
        Task<Employee> EditRecard(int id);
        Task<bool> UpdateRecard(Employee data);
        Task<bool> DeleteRecard(int id);
        Task<Employee> DetailsRecard(int id);
    }
}
