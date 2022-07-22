using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Domain.DTO;
using User.WebAPI.Data;
using User.WebAPI.Repositories;

namespace User.WebAPI.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionsController : Controller
    {
        ApplicationDbContext _db;
        private readonly IRegionRepository _regionRepository;
        private IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
           
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
           var regions= await _regionRepository.GetAllAsync();

            //return DTO regions
            //var regionsDTO = new List<RegionDTO>();

            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new RegionDTO()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population



            //    };
            //    regionsDTO.Add(regionDTO);
            //});
            //map all domain regions to regionsDTO and pass to cleint
            var regionsDTO = _mapper.Map<List<RegionDTO>>(regions);

            return Ok(regionsDTO);
        }


    }
}
