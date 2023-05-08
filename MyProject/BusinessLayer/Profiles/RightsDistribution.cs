using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;

namespace BusinessLayer.Profiles
{
    public  class RightsDistributionProfile : Profile
    {
        public RightsDistributionProfile()
        {
            CreateMap<RightDistributionPermissionDto, RightsDistribution>();
            CreateMap<RightsDistribution, RightDistributionPermissionDto>();

        }
    }
}
