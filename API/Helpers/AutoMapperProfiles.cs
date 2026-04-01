using API.Models.Domain;
using API.Models.DTOs;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        
        public AutoMapperProfiles() 
        {
            CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<UserDto ,User>();
        }
       
    }
}
