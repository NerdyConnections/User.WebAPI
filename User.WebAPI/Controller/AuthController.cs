using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Domain.DTO;
using User.Domain.Models;
using User.WebAPI.Data;
using User.WebAPI.Repositories;

namespace User.WebAPI.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly ITokenHandler _tokenHandler;

        public AuthController(IClientRepository clientRepository,ITokenHandler tokenHandler)
        {
            _clientRepository = clientRepository;
            _tokenHandler = tokenHandler;
        }
        
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO loginDTO)
        {
            //check if user is authenticated
            //check username and password

           var client= await _clientRepository.AuthenticateAsync(loginDTO.Username, loginDTO.Password);

            if (client != null)
            {
                //Generate a JWT Token
              var token=  await _tokenHandler.CreateTokenAsync(client);
                return Ok(token);

            }
            return BadRequest("Username or Password is incorrect.");


        }
       
       

        
        

        
    }
}
