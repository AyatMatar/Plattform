using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        public string? Experience { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Linkedin { get; set; }
        public string? ImgName { get; set; }

    }
}
