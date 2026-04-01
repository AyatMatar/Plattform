namespace API.Models.Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;
        public string? IconClass { get; set; } = string.Empty;

        public virtual List<Course>? Courses { get; set; } 
        public virtual List<UserDepartment>? UserDepartments { get; set; }
    }
}
