using API.Models.Domain;
using API.Models.DTOs;
using API.Repsitories.Abstract;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API.Repsitories.Implemintation
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;

        public UserRepository(DatabaseContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> AddUpdateUser(UserDto userDto)
        {

            try
            {
                //User userObj = new User(userDto.Id , userDto.NationalNumber , userDto.FirstName, userDto.LastName
                //    , userDto.Address, userDto.PhoneNumber, userDto.Email, userDto.DateOfBirth, userDto.CreationDate,userDto.UpdateDate ,
                //    userDto.Gender, userDto.Username, userDto.Password);
                //User user = new User
                //{
                //    Id= userDto.Id,
                //    NationalNumber = userDto.NationalNumber,
                //    FirstName = userDto.FirstName,
                //    LastName = userDto.LastName,
                //    Address= userDto.Address,
                //    PhoneNumber = userDto.PhoneNumber,
                //    Email = userDto.Email,
                //    DateOfBirth = userDto.DateOfBirth,
                //    Gender = userDto.Gender,
                //    Username = userDto.Username, 
                //    Password = userDto.Password,
                //    CreationDate = userDto.CreationDate,

                //};

                User user = _mapper.Map<User>(userDto);

                if(user.Id == 0)
                {
                    user.CreationDate = DateTime.Now;
                    await _db.Users.AddAsync(user);
                }

                else
                {
                    
                    user.UpdateDate = DateTime.Now;
                    _db.Users.Update(user);
                }
                   

                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(int Id)
        {
            try
            {
                var record = await _db.Users.FirstOrDefaultAsync(user => user.Id == Id);
                if (record == null)
                    return false;
               
                _db.Users.Remove(record);
                _db.SaveChanges();
                return true;
               
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<UserDto>> GetAllUser()
        {
            var result = await _db.Users.ToListAsync();
            var lstUserDto = _mapper.Map<List<UserDto>>(result);
            return lstUserDto;
        }

  
        public async Task<UserDto> GetUserById(int Id)
        {
            var result = await _db.Users.FirstOrDefaultAsync(user => user.Id == Id);
            // return _db.Users.Find(Id);
            UserDto user = _mapper.Map<UserDto>(result);
            return user;
        }

        public async Task<UserLoginResponseDto> GetLoginUser(UserLoginReqDto user)
        {
            var result = await _db.Users.FirstOrDefaultAsync( us => us.Username.ToLower() == user.Username /*&& us.Password == user.Password */);
            var userResult = new UserLoginResponseDto
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
            };
            return userResult;
        }

        public async Task<User> GetLoginUserTest(User user)
        {
            return await _db.Users.FirstOrDefaultAsync(us => us.Username.ToLower() == user.Username /*&& us.Password == user.Password*/);
        }

        public async Task<List<TeamDto>> GetTeam()
        {
            try
            {
                var result = await _db.Users.Where(user => user.Role.ToUpper() == Constants.Constants.Role.Admin || 
                user.Role.ToUpper() == Constants.Constants.Role.Teacher).Select(user => new TeamDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role,
                    Experience = user.Experience,
                    Twitter = user.Twitter,
                    Facebook = user.Facebook,
                    Instagram= user.Instagram,
                    Linkedin = user.Linkedin,
                    ImgName =  user.ImgName
                }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
