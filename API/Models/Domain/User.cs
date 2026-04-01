using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class User
    {
        public User() { }
        public User(int id, string? nationalNumber, string? firstName, string? lastName,
          string? address, string? phoneNumber, string? email, DateTime? dateOfBirth,
          DateTime? creationDate, DateTime? updateDate, string? gender, string? username, string? password)
        {
            Id = id;
            NationalNumber = nationalNumber;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
            CreationDate = creationDate;
            UpdateDate = updateDate;
            Gender = gender;
            Username = username;
            //Password = password;
        }
        public int Id { get; set; }
        [Required]
        public string? NationalNumber { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Gender { get; set; }
        public string? Username { get; set; }
        //public string? Password { get; set; }
        public byte[] Password { get; set; }
        public byte[] Passwordkey { get; set; }

        public virtual List<UserDepartment>? UserDepartments { get; set; }
        public virtual List<Section>? Sections { get; set; } 
        //Admin Teacher Student 
        public string? Role { get; set; }
        public string? Token { get; set; }
        public string? Experience { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Linkedin { get; set; }
        public string? ImgName { get; set; }


    }
}
