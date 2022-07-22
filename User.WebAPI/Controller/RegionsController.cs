using Microsoft.AspNetCore.Mvc;
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

        
        public RegionsController(IRegionRepository regionRepository)
        {
           
            _regionRepository = regionRepository;
        }
        [HttpGet]
        public IActionResult GetAllRegions()
        {
           var regions= _regionRepository.GetAll();

            return Ok(regions);
        }


    }
}
