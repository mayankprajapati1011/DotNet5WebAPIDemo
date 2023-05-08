using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;

namespace BusinessLayer.Profiles
{
    public class RoleProfile :Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleForCreateDto, Role>();
            CreateMap<Role,RoleForCreateDto>();
            CreateMap<Role, RoleForListDto>();
            CreateMap<Role, ComboDto>();
        }
    }
}
