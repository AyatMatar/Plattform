using API.Models.Domain;
using API.Models.DTOs;
using API.Repsitories.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Repsitories.Implemintation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;
        public AuthRepository(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task <UserLoginDto> Login(UserForLoginDto userDto)
        {
           
            //var record = await _db.Users.FirstOrDefaultAsync(us => us.Username.ToLower() == userDto.UserName.ToLower() && us.Password == userDto.Password);
            UserLoginDto record;
            try
            {

                var user = await _db.Users.Where(user => user.Username.ToLower() == userDto.UserName.ToLower()).FirstOrDefaultAsync();
                //.Select(user => new UserLoginDto
                //{
                //    Id = user.Id,
                //    UserName = user.Username,
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Role = user.Role
                //}).FirstOrDefaultAsync() ?? new UserLoginDto();
                if (user == null || user.Passwordkey == null)
                    return null;
                if (!MatchPasswordHash(userDto.Password, user.Password, user.Passwordkey))
                    return null;
                UserLoginDto result = new UserLoginDto
                {
                    Id = user.Id,
                    UserName = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role
                };
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Reister(UserDto userDto)
        {
            byte[] passwordkey, passwordHash;
            using (var hmac = new HMACSHA512())
            {
                passwordkey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userDto.Password));
            }


                User user = new User
                {
                    Id = userDto.Id,
                    NationalNumber = userDto.NationalNumber,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Address = userDto.Address,
                    PhoneNumber = userDto.PhoneNumber,
                    Email = userDto.Email,
                    DateOfBirth = userDto.DateOfBirth,
                    Gender = userDto.Gender,
                    Username = userDto.Username,
                    // Password = userDto.Password,
                   // CreationDate = userDto.CreationDate,

                };
            user.Password = passwordHash;
            user.Passwordkey = passwordkey;
            user.CreationDate = DateTime.Now;
            await _db.Users.AddAsync(user);
            _db.SaveChanges();
            return true;
        }

        public async Task<bool> UserAlreadyExisits(string userName)
        {
            return await _db.Users.AnyAsync(user => user.Username == userName);
        }
   
        private bool MatchPasswordHash(string passwordText , byte[] password , byte[] passwordkey)
        {
           using(var hmac = new HMACSHA512(passwordkey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));
                for (int i = 0; i< passwordHash.Length; i++)
                {
                    if (passwordHash[i] != password[i])
                        return false;
                }
                return true;
            }
        }
    
    }
}
