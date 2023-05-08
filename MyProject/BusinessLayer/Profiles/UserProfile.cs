using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;

namespace BusinessLayer.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForCreateDto, User>();
            CreateMap<User, UserDto>()
                .ForMember(ur => ur.RoleName, u => u.MapFrom(x => x.Role.Name));
            CreateMap<User, ComboDto>()
                .ForMember(ur => ur.Name, u => u.MapFrom(x => x.FullName));
        }
    }
}
