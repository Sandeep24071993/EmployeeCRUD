using EmployeeCRUD.Models;

namespace EmployeeCRUD.DesignationService
{
    public interface IDesignationService
    {
        Task<IEnumerable<Designation>> GetDesignation();
        Task<int> AddDesignation(Designation data);
        Task<Designation> EditGetId(int id);
        Task<bool> UpdateDesignation(Designation data);
        Task<bool> DeleteRecard(int id);
    }
}
