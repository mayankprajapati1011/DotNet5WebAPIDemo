using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using System.Linq;

namespace BusinessLayer.Profiles
{
   public class MenuProfile :Profile
    {
        public MenuProfile()
        {
            CreateMap<ChildMenu, MenuDto>();
            CreateMap<ParentMenu, ParentMenuDto>();
            CreateMap<ChildMenu, MenuForRightsDistributionDto>()
           .ForMember(a => a.AllowAdd, b => b.MapFrom(c => c.RightsDistribution.SingleOrDefault(x => x.AllowAdd)))
           .ForMember(a => a.AllowDelete, b => b.MapFrom(c => c.RightsDistribution.SingleOrDefault(x => x.AllowDelete)))
           .ForMember(a => a.AllowPrint, b => b.MapFrom(c => c.RightsDistribution.SingleOrDefault(x => x.AllowPrint)))
           .ForMember(a => a.AllowUpdate, b => b.MapFrom(c => c.RightsDistribution.SingleOrDefault(x => x.AllowUpdate)))
           .ForMember(a => a.AllowView, b => b.MapFrom(c => c.RightsDistribution.SingleOrDefault(x => x.AllowView)));
        }
    }
}
