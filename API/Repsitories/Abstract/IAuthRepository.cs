using API.Models.Domain;
using API.Models.DTOs;
using System.Diagnostics.Eventing.Reader;

namespace API.Repsitories.Abstract
{
    public interface IAuthRepository
    {
        Task<UserLoginDto> Login(UserForLoginDto userDto);
        Task<bool> Reister(UserDto userDto);
        Task<bool> UserAlreadyExisits(string userName);

    }
}
