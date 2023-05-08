using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;

namespace BusinessLayer.Profiles
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<StateForCreateDto, State>();
            CreateMap<State, StateForCreateDto>();
            CreateMap<State, StateForListDto>();
            CreateMap<State, ComboDto>();

            CreateMap<StateCity, StateForCreateDto>().ForMember(dest => dest.Name, plz => plz.MapFrom(src => src.StateName ) );
            CreateMap<StateCity, CityForCreateDto>().ForMember(dest => dest.Name, plz => plz.MapFrom(src => src.CityName));
        }
    }
}
