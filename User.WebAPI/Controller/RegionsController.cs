using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Domain.DTO;
using User.Domain.Models;
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

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(int Id)
        {
            var region = await _regionRepository.GetAsync(Id);
            if (region == null)
            {
                return NotFound();

            }
            var regionDTO = _mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);

        }
        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionDTO addRegionDTO)

        {
            //request to domain model
            var region = new Region()
            {
                Code = addRegionDTO.Code,
                Area = addRegionDTO.Area,
                Lat = addRegionDTO.Lat,
                Long = addRegionDTO.Long,
                Name = addRegionDTO.Name,
                Population = addRegionDTO.Population
            };
            //   var region = _mapper.Map<Region>(addRegionDTO);


            //pass details to repository
            region = await _regionRepository.AddAsync(region);

            //var regionDTO = _mapper.Map<AddRegionDTO>(region);

            //convert back to dto
            var regionDTO = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population

            };
            //http 201, client knows save is successful
            //acdtion return when object is found

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRegionAsync(int Id)
        {
            //get region from db

            Region region = await _regionRepository.DeleteAsync(Id);

            if (region == null)
            {
                return NotFound();
            }

            //not found
            //
            var regionDTO = new RegionDTO
            {

                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };
            return Ok(regionDTO);


            //return ok
        }
    }
}
