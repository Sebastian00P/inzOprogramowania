using inzOprogramowania.Services.UserService.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inzOprogramowania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IUserService _userService;
        public AdsController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
