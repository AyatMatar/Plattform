namespace API.Models.Domain
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TotalHoures { get; set; }
        public int LecturesPerWeek { get; set; }
        public int? TimeFrom { get; set; }
        public int? TimeTo { get; set; }
        public virtual Course? Course { get; set; } 
        public virtual int CourseId { get; set; }
        public virtual User? Teacher { get; set; }
        public virtual int TeacherId { get; set; }
    }
}
