
namespace API.Models.DTOs
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public GetCourseDto? Course { get; set; } = new GetCourseDto();

        //public int CourseId { get; set; }
        public TeacherDto? Teacher { get; set; } = new TeacherDto();
        //public int TeacherId { get; set; }
        public int TotalHoures { get; set; }
        public int LecturesPerWeek { get; set; }
        public int? TimeFrom { get; set; }
        public int? TimeTo { get; set; }
    }
    public class SectionAddUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CourseId { get; set; } 

        public int TeacherId { get; set; }
        public int TotalHoures { get; set; }
        public int LecturesPerWeek { get; set; }
        public int? TimeFrom { get; set; }
        public int? TimeTo { get; set; }
    }
}
