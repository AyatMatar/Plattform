using API.Models.Domain;
using API.Models.DTOs;

namespace API.Repsitories.Abstract
{
    public interface IDepartmentRepository
    {
        public Task <DepartmentDto> GetDepartmentById(int id);
        public Task<bool> AddUpdateDepartment(Department user);
        public Task<List<DepartmentDto>> GetAllDepartment();
        public Task<List<DepartmentLookupDto>> GetAllDepartmentLookup();
        public Task <bool> DeleteDepartment(int Id);

    }
}
