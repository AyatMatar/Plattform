namespace API.Models.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Department? Department { get; set; }
        public virtual int? DepartmentId { get; set; }
        public virtual List<Section>? Sections { get; set; }
    }
}
