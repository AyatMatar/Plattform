

namespace API.Models.DTOs
{
    public class UserLoginReqDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }


    public class UserLoginResponseDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class TeacherDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Experience { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Linkedin { get; set; }
        public string? ImgName { get; set; }

    }
}
