using EmployeeCRUD.Data;
using EmployeeCRUD.DepartmentRepository.Interface;
using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.DepartmentRepository.Service
{
    public class DepartmentRepository : IDepartment
    {
        private readonly EmployeeDbContext _context;
        public DepartmentRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _context.Departments.ToListAsync();
        }
        public async Task<int> AddDepartment(Department data)
        {
            await _context.Departments.AddAsync(data);
            await _context.SaveChangesAsync();
            return data.Id;
        }
        public async Task<Department> EditGetId(int id)
        {
            var data = await _context.Departments.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> UpdateDepartment(Department data)
        {
            bool status = false;
            if (data != null)
            {
                _context.Departments.Update(data);
                await _context.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        public async Task<bool> DeleteRecard(int id)
        {
            bool status = false;
            if (id != 0)
            {
                var data = await _context.Departments.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    _context.Departments.Remove(data);
                    await _context.SaveChangesAsync();
                    status = true;
                }
            }
            return status;
        }
    }

}
