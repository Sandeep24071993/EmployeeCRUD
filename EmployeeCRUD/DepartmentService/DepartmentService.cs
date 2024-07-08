using EmployeeCRUD.DepartmentRepository.Interface;
using EmployeeCRUD.Models;

namespace EmployeeCRUD.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartment _context;
        public DepartmentService(IDepartment context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _context.GetDepartment();
        }
        public Task<int> AddDepartment(Department data)
        {
            return _context.AddDepartment(data);
        }

        public async Task<Department> EditGetId(int id)
        {
            return await _context.EditGetId(id);
        }

        public async Task<bool> UpdateDepartment(Department data)
        {
            return await _context.UpdateDepartment(data);
        }

        public async Task<bool> DeleteRecard(int id)
        {
            return await _context.DeleteRecard(id);
        }
    }
}
