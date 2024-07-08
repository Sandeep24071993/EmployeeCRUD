using EmployeeCRUD.Models;

namespace EmployeeCRUD.DesignationRepository.Interface
{
    public interface IDesignation
    {
        Task<IEnumerable<Designation>> GetDesignation();
        Task<int> AddDesignation(Designation data);
        Task<Designation> EditGetId(int id);
        Task<bool> UpdateDesignation(Designation data);
        Task<bool> DeleteRecard(int id);
    }
}
