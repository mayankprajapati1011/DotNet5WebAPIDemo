using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;

namespace BusinessLayer.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityForCreateDto, City>();
            CreateMap<City, CityForCreateDto>();
            CreateMap<City, CityForListDto>();
            CreateMap<City, ComboDto>();
        }
    }
}
