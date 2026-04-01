using API.Models.DTOs;
using API.Repsitories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task <IActionResult> Login(UserForLoginDto user)
        {            
            var result = await _authRepository.Login(user);
            if (result == null)
                return new UnauthorizedResult();

            // create jwt
            result.Token = CreateJWT(result);
            return Ok(result);      
        }

        private string CreateJWT(UserLoginDto user)
        {
            var secretKey = _configuration.GetSection("AppSettings:key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name , user.FirstName+" "+user.LastName),
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Role , user.Role?? "")
            };

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(15),
                SigningCredentials = signingCredentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto user)
        {
            if (await _authRepository.UserAlreadyExisits(user.Username))
                return BadRequest("User Already exists, Please try different user name..!");
            var result = await _authRepository.Reister(user);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Add user Successefully" : "Error throw Saving....!"
            };
            return Ok(status);
        }
    }
}
