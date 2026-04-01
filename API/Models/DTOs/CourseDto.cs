using API.Models.Domain;

namespace API.Models.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; }
    }

    public class GetCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DepartmentDto? Department { get; set; }
    }


}
