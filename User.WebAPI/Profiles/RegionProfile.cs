using AutoMapper;
using User.Domain.DTO;
using User.Domain.Models;

namespace User.WebAPI.Profiles
{
    public class RegionProfile:Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
        }
    }
}
