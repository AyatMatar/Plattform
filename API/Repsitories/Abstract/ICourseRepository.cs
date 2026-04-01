using API.Models.Domain;
using API.Models.DTOs;

namespace API.Repsitories.Abstract
{
    public interface ICourseRepository
    {
        Task<CourseDto> GetById(int Id);
        Task<List<CourseDto>> GetAll();
        Task<bool> AddUpdate(CourseDto course);
        Task<bool> Delete(int Id);
        Task<List<CourseDto>> GetCoursesByDepartmentId(int DepartmentId);
    }
}
