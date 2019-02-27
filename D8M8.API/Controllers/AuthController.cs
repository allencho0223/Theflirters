using System.Threading.Tasks;
using D8M8.API.Data;
using D8M8.API.Dtos;
using D8M8.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace D8M8.API.Controllers
{
    [Route("api/[controller]")]
    // APIController attribute somewhat controls data annotations(?)
    // This allows asp.net core mvc to infer where the data is coming from in terms of our data and parameters
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            this._repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            /*
                // If we don't use APIController attribute,
                // change Register parameter as ([FromBody]UserForRegisterDto userForRegisterDto)
                //and uncomment the code below
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            
             */
            

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username)) {
                return BadRequest("Username already exists");
            }

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}