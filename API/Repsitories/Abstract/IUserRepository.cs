using API.Models.Domain;
using API.Models.DTOs;

namespace API.Repsitories.Abstract
{
    public interface IUserRepository
    {
        Task<bool> AddUpdateUser(UserDto user);
        Task<List<UserDto>> GetAllUser();
        Task<bool> DeleteUser(int Id);

        Task<UserDto> GetUserById(int Id);

        Task<UserLoginResponseDto> GetLoginUser(UserLoginReqDto user);
        Task<User> GetLoginUserTest(User user);

        Task<List<TeamDto>> GetTeam();

    }
}
