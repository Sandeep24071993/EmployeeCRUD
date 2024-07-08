using EmployeeCRUD.DesignationRepository.Interface;
using EmployeeCRUD.Models;

namespace EmployeeCRUD.DesignationService
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignation _context;
        public DesignationService(IDesignation context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Designation>> GetDesignation()
        {
            return await _context.GetDesignation();
        }
        public Task<int> AddDesignation(Designation data)
        {
            return _context.AddDesignation(data);
        }

        public async Task<Designation> EditGetId(int id)
        {
            return await _context.EditGetId(id);
        }

        public async Task<bool> UpdateDesignation(Designation data)
        {
           return await _context.UpdateDesignation(data);
        }

        public async Task<bool> DeleteRecard(int id)
        {
            return await _context.DeleteRecard(id);
        }
    }
}
