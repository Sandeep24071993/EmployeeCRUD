using EmployeeCRUD.EmployeeRepository.Interface;
using EmployeeCRUD.Models;

namespace EmployeeCRUD.EmployeeService
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IEmployee _context;
        public EmployeeService(IEmployee context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await _context.GetEmployee();
        }

        public async Task<int> AddEmployee(Employee data)
        {
            return await _context.AddEmployee(data);
        }

        public async Task<bool> DeleteRecard(int id)
        {
            return await _context.DeleteRecard(id);
        }

        public async Task<Employee> DetailsRecard(int id)
        {
            return await _context.DetailsRecard(id);
        }

        public async Task<Employee> EditRecard(int id)
        {
            return await _context.EditRecard(id);
        }

        public async Task<bool> UpdateRecard(Employee data)
        {
            return await _context.UpdateRecard(data); 
        }
    }
}
