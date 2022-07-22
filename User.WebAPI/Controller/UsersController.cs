using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Domain.DTO;
using User.WebAPI.Repositories;

namespace User.WebAPI.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }



        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var usersDTO = _mapper.Map<List<UserModelDTO>>(users);

            return Ok(usersDTO);
            
        }
    }
}
