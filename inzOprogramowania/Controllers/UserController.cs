using inzOprogramowania.Services;
using Microsoft.AspNetCore.Mvc;

namespace inzOprogramowania.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("TryAuth")]
        [HttpPost]
        public async Task<IActionResult> TryLogin(string login, string password)
        {
            var hashPWD = _userService.GetMd5Hash(password);
            var user = await _userService.GetUserByUserNameAndPassword(login, hashPWD);
            if (user != null)
            {
                return Ok();
            }
            else
            {              
                return BadRequest();
            }
        }
    }
}
