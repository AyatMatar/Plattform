using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs
{
    public class UserForLoginDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class UserLoginDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

    }

}
