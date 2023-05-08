using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.Entity;

namespace BusinessLayer.Profiles
{
    public class ZoneProfile  : Profile
    {
        public ZoneProfile()
        {
            CreateMap<Zone, ComboDto> ();
        }
    }
}
