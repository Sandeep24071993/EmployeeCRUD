using EmployeeCRUD.Data;
using EmployeeCRUD.DesignationRepository.Interface;
using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.DesignationRepository.Service
{
    public class DesignationRepository : IDesignation
    {
        private readonly EmployeeDbContext _context;
        public DesignationRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Designation>> GetDesignation()
        {
            return await _context.Designations.ToListAsync();
        }
        public async Task<int> AddDesignation(Designation data)
        {
            await _context.Designations.AddAsync(data);
            await _context.SaveChangesAsync();  
            return data.Id;
        }
        public async Task<Designation> EditGetId(int id)
        {
            var data = await _context.Designations.Where(x=>x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> UpdateDesignation(Designation data)
        {
            bool status = false;
            if (data != null)
            {
                 _context.Designations.Update(data);
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
                var data = await _context.Designations.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (data != null)
                {
                    _context.Designations.Remove(data); 
                    await _context.SaveChangesAsync();
                    status = true;  
                }
            }
            return status;
        }
    }
}
