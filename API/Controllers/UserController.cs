using API.Models.Domain;
using API.Models.DTOs;
using API.Repsitories.Abstract;
using API.Repsitories.Implemintation;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
 
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }


        [HttpPost("AddUpdateUser")]
        public async Task<IActionResult> AddUpdateUser(UserDto user)
        {
            var result = await _userRepository.AddUpdateUser(user);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Saved Successefully" : "Error throw Saving....!"
            };
            return Ok(status);
        }

        [HttpGet("getAllUser")]
        public async Task< IActionResult> GetAllUser()
        {
            var result = await _userRepository.GetAllUser();
            
            return Ok(result);
        }

        [HttpDelete("deleteUser/{id}")]    //api/User/deleteUser/2
        public async Task<IActionResult> DeleteUser(int id) 
        {
            var result = await _userRepository.DeleteUser(id);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Delete Successefully" : "Error throw Deleting....!"
            };
            return Ok(status);
        }
        [HttpGet("getUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete(int id)
        {
            var result = _userRepository.DeleteUser(id);
        }

        [HttpPost("getLoginUser")]
        public async Task<UserLoginResponseDto> GetLoginUser(UserLoginReqDto user)
        {
            var result = await _userRepository.GetLoginUser(user);

            return result;
        }
        [HttpPost("getLoginUserTest")]
        public async Task<UserLoginResponseDto> GetLoginUserTest(UserLoginReqDto user)
        {
            var userEntity = new User
            {
                Username = user.Username,
                //Password = user.Password

            };
            var result =await _userRepository.GetLoginUserTest(userEntity);

            return new UserLoginResponseDto { FirstName = result.FirstName, LastName = result.LastName, Id = result.Id };
        }
        [HttpGet("getTeam")]
        public async Task<IActionResult> GetTeam()
        {
            var result = await _userRepository.GetTeam();
            return Ok(result);
        }
    }
}
