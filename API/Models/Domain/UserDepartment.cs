namespace API.Models.Domain
{
    public class UserDepartment
    {
        public int Id { get; set; }

        public virtual User User { get; set; }
        public virtual int UserId { get; set; }
        public virtual Department Department { get; set; }
        public virtual int DepartmentId { get; set; }
    }
}
