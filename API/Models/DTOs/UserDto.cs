using API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs
{
    public class UserDto
    {
        public UserDto()
        {
            
        }

        public int Id { get; set; }
        public string? NationalNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Gender { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

}
