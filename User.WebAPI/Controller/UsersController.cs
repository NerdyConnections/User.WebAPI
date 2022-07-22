using Microsoft.AspNetCore.Mvc;
using User.WebAPI.Repositories;

namespace User.WebAPI.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }



        [HttpGet]
        public IActionResult GetAllUserss()
        {
            var users = _userRepository.GetAll();

            return Ok(users);
        }
    }
}
