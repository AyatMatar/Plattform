using API.Models.Domain;
using API.Models.DTOs;
using API.Repsitories.Abstract;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using SectionEntity = API.Models.Domain.Section;
namespace API.Repsitories.Implemintation
{
    public class SectionRepository : ISectionRepository
    {
        private readonly DatabaseContext _db;
        public SectionRepository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<bool> AddUpdate(SectionAddUpdateDto sectionDto)
        {
            try
            {
                if (sectionDto == null)
                    return false;

                SectionEntity section = new SectionEntity
                {
                    Id = sectionDto.Id,
                    Name = sectionDto.Name,
                    CourseId = sectionDto.CourseId,
                    TeacherId = sectionDto.TeacherId,
                    TotalHoures = sectionDto.TotalHoures,
                    LecturesPerWeek = sectionDto.LecturesPerWeek,
                    TimeFrom = sectionDto.TimeFrom,
                    TimeTo = sectionDto.TimeTo

                };
                if (section.Id == 0)
                {
                    //add
                    await _db.Sections.AddAsync(section);
                }
                else
                {
                    //update
                    _db.Sections.Update(section);
                }
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                var record = await _db.Sections.FirstOrDefaultAsync(section => section.Id == Id);
                if (record == null)
                    return false;
                _db.Sections.Remove(record);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<SectionDto>> GetAll()
        {
            try
            {
                List<SectionDto> result = await _db.Sections.Select(section => new SectionDto 
                {
                    Id = section.Id,
                    Name = section.Name,
                    Teacher = new TeacherDto
                    {
                        Id = (int)section.Teacher.Id,
                        FirstName = section.Teacher.FirstName,
                        LastName = section.Teacher.LastName,
                    },
                    TotalHoures = section.TotalHoures,
                    LecturesPerWeek = section.LecturesPerWeek,
                    TimeFrom = section.TimeFrom,
                    TimeTo = section.TimeTo,
                    Course = new GetCourseDto
                    {
                        Id = section.CourseId,
                        Name = section.Course.Name,
                        Description = section.Course.Description,
                        Department = new DepartmentDto
                        {
                            // Id =(int) section.Course.DepartmentId,
                            Id = (section == null) ? 0 : (section.Course == null) ? 0 : (int)section.Course.DepartmentId,
                            //Name = section.Course.Department.Name,
                            Name = section == null ? "" : section.Course == null ? "" : section.Course.Department == null ? "" : section.Course.Department.Name,
                            //IconClass = section.Course.Department.IconClass,
                            IconClass = (section != null) ? (section.Course != null) ? (section.Course.Department != null) ? section.Course.Department.IconClass : "" : "" : "",
                            //Description = section.Course.Department.Description
                            Description = (section != null) ? (section.Course != null) ? (section.Course.Department != null) ? section.Course.Department.Description : "" : "" : ""
                        }
                    }
                }).ToListAsync();

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SectionDto> GetById(int Id)
        {
            try
            {
                var result = await _db.Sections.Where(section => section.Id == Id).Select(section => new SectionDto
                {
                    Id = section.Id,
                    Name = section.Name,
                    Teacher = new TeacherDto
                    {
                        Id = (int)section.Teacher.Id,
                        FirstName = section.Teacher.FirstName,
                        LastName = section.Teacher.LastName,
                        Experience = section.Teacher.Experience,
                        Twitter = section.Teacher.Twitter,
                        Facebook = section.Teacher.Facebook,
                        Instagram = section.Teacher.Instagram,
                        Linkedin = section.Teacher.Linkedin,
                        ImgName = section.Teacher.ImgName
                    },
                    TotalHoures = section.TotalHoures,
                    LecturesPerWeek = section.LecturesPerWeek,
                    TimeFrom = section.TimeFrom,
                    TimeTo = section.TimeTo,
                    Course = new GetCourseDto
                    {
                        Id = section.CourseId,
                        Name = section.Course.Name,
                        Description = section.Course.Description,
                        Department = new DepartmentDto
                        {
                            // Id =(int) section.Course.DepartmentId,
                            Id = (section == null) ? 0 : (section.Course == null) ? 0 : (int)section.Course.DepartmentId,
                            //Name = section.Course.Department.Name,
                            Name = section == null ? "" : section.Course == null ? "" : section.Course.Department == null ? "" : section.Course.Department.Name,
                            //IconClass = section.Course.Department.IconClass,
                            IconClass = (section != null) ? (section.Course != null) ? (section.Course.Department != null) ? section.Course.Department.IconClass : "" : "" : "",
                            //Description = section.Course.Department.Description
                            Description = (section != null) ? (section.Course != null) ? (section.Course.Department != null) ? section.Course.Department.Description : "" : "" : ""
                        }
                    }
                }).FirstOrDefaultAsync();

                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<SectionDto>> GetSectionByCourseId(int courseId)
        {
            try
            {
                List<SectionDto> result = await _db.Sections.Where(section => section.CourseId == courseId).Select(section => new SectionDto
                {
                    Id = section.Id,
                    Name = section.Name,
                    Teacher = new TeacherDto
                    {
                        Id = (int)section.Teacher.Id,
                        FirstName = section.Teacher.FirstName,
                        LastName = section.Teacher.LastName,
                        Experience = section.Teacher.Experience,
                        Twitter = section.Teacher.Twitter,
                        Facebook = section.Teacher.Facebook,
                        Instagram = section.Teacher.Instagram,
                        Linkedin = section.Teacher.Linkedin,
                        ImgName = section.Teacher.ImgName,
                        },
                    TotalHoures = section.TotalHoures,
                    LecturesPerWeek = section.LecturesPerWeek,
                    TimeFrom = section.TimeFrom,
                    TimeTo = section.TimeTo,
                    Course = new GetCourseDto
                    {
                        Id = section.CourseId,
                        Name = section.Course.Name,
                        Description = section.Course.Description,
                        Department = new DepartmentDto
                        {
                            // Id =(int) section.Course.DepartmentId,
                            Id = (section == null) ? 0 : (section.Course == null) ? 0 : (int)section.Course.DepartmentId,
                            //Name = section.Course.Department.Name,
                            Name = section == null ? "" : section.Course == null ? "" : section.Course.Department == null ? "" : section.Course.Department.Name,
                            //IconClass = section.Course.Department.IconClass,
                            IconClass = (section != null) ? (section.Course != null) ? (section.Course.Department != null) ? section.Course.Department.IconClass : "" : "" : "",
                            //Description = section.Course.Department.Description
                            Description = (section != null) ? (section.Course != null) ? (section.Course.Department != null) ? section.Course.Department.Description : "" : "" : ""
                        }
                    }
                }).ToListAsync();

                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
