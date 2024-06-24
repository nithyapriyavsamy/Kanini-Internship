using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models.DTO;
using UserManagement.Services;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<UserDTO> Login([FromQuery]LoginDTO loginDTO)
        {
            UserDTO userDTO = new UserDTO();
            userDTO = _service.Login(loginDTO);
            if(userDTO != null)
            {
                return Ok(userDTO);
            }
            return BadRequest("Username or Password is incorrect");
        }
        [HttpPost]
        public ActionResult<UserDTO> Register(RegisterDTO registerDTO)
        {
            UserDTO userDTO= new UserDTO();
            userDTO= _service.Register(registerDTO);
            if(userDTO != null)
            {
                return Ok(userDTO);
            }
            return BadRequest("can't register the user");
        }
    }
}
