using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Domain.DTO;
using User.Domain.Models;
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
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var usersDTO = _mapper.Map<List<UserModelDTO>>(users);

            return Ok(usersDTO);
            
        }

        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetUserAsync")]
        public async Task<IActionResult> GetUserAsync(int Id)
        {
            var user = await _userRepository.GetAsync(Id);
            if (user == null)
            {
                return NotFound();

            }
            var userDTO = _mapper.Map<UserModelDTO>(user);
            return Ok(userDTO);

        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserModelDTO addUserModelDTO)

        {
            //Validate Request

            if (!ValidAddUserAsync(addUserModelDTO))
            {
                return BadRequest();   
            }

            //convert dto model to domain model
            var userModel = new UserModel()
            {
                FirstName = addUserModelDTO.FirstName,
                LastName = addUserModelDTO.LastName,
                Age = addUserModelDTO.Age,
                Phone = addUserModelDTO.Phone,
                DepartmentId = addUserModelDTO.DepartmentId,
                CreatedBy = addUserModelDTO.CreatedBy,
                DateCreated = addUserModelDTO.DateCreated,
                LastModifiedBy= addUserModelDTO.LastModifiedBy,
                LastModifiedDate = addUserModelDTO.LastModifiedDate

            };
          
            //pass details to repository
            userModel = await _userRepository.AddAsync(userModel);

            //convert back to dto
           
            var userDTO = new AddUserModelDTO
            {
                Id= userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Age = userModel.Age,
                Phone = userModel.Phone,
                DepartmentId= userModel.DepartmentId,
                CreatedBy = userModel.CreatedBy,
                DateCreated = userModel.DateCreated,
                LastModifiedBy = userModel.LastModifiedBy,
                LastModifiedDate = userModel.LastModifiedDate

            };
            //http code 201, client knows save is successful
            //action return when object is found

            return CreatedAtAction(nameof(GetUserAsync), new { id = userDTO.Id }, userDTO);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int Id)
        {
            //get user from db

            UserModel user = await _userRepository.DeleteAsync(Id);
            //not found
            if (user == null)
            {
                return NotFound();
            }

            
            //convert domain to dto
            var userDTO = new UserModelDTO
            {

                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Phone = user.Phone,
                DepartmentId = user.DepartmentId,
                CreatedBy = user.CreatedBy,
                DateCreated = user.DateCreated,
                LastModifiedBy = user.LastModifiedBy,
                LastModifiedDate = user.LastModifiedDate
            };
            //return 200 and the user deleted
            return Ok(userDTO);


            
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            //convert dto to domain
          
            var userModel = new UserModel()
            {
                FirstName = updateUserDTO.FirstName,
                LastName = updateUserDTO.LastName,
                Age = updateUserDTO.Age,
                Phone = updateUserDTO.Phone,
                DepartmentId = updateUserDTO.DepartmentId,
                
                LastModifiedBy = updateUserDTO.LastModifiedBy,
                LastModifiedDate = updateUserDTO.LastModifiedDate

            };
          
            //update user using repository
            userModel = await _userRepository.UpdateAsync(id,userModel);

            //if null then not found
            if (userModel == null)
            {
                return NotFound();

            }

            //convert domain back to dto
            var userDTO = new UpdateUserDTO
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Age = userModel.Age,
                Phone = userModel.Phone,
                DepartmentId = userModel.DepartmentId,
                
                LastModifiedBy = userModel.LastModifiedBy,
                LastModifiedDate = userModel.LastModifiedDate

            };

            //return ok response
            return Ok(userDTO);

        }
        #region
        private bool ValidAddUserAsync(AddUserModelDTO addUserModelDTO)
        {
            if (addUserModelDTO == null)
            {


                ModelState.AddModelError(nameof(addUserModelDTO), $"User Data is missing.");
                return false;

            }
            if (String.IsNullOrWhiteSpace(addUserModelDTO.FirstName))
            {

                ModelState.AddModelError(nameof(addUserModelDTO.FirstName), $"{nameof(addUserModelDTO.FirstName)} cannot be null or empty or white space.");
            }
            if (String.IsNullOrWhiteSpace(addUserModelDTO.LastName))
            {

                ModelState.AddModelError(nameof(addUserModelDTO.LastName), $"{nameof(addUserModelDTO.FirstName)} cannot be null or empty or white space.");
            }
            if (addUserModelDTO.Age <= 0  )
            {

                ModelState.AddModelError(nameof(addUserModelDTO.Age), $"{nameof(addUserModelDTO.Age)} cannot be less than or equal zero");
            }
            if (ModelState.ErrorCount> 0)
            {
                return false;
            }
            return true;
        }
        #endregion

    }
}
