

using API.Models.DTOs;

namespace API.Repsitories.Abstract
{
    public interface ISectionRepository
    {
        Task<SectionDto> GetById(int Id);
        Task<List<SectionDto>> GetAll();
        Task<bool> AddUpdate(SectionAddUpdateDto section);
        Task<bool> Delete(int Id);
        Task<List<SectionDto>> GetSectionByCourseId(int courseId);
    }
}
