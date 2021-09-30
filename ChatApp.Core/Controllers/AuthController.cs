using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using ChatApp.Core.Services.Interfaces;
using ChatApp.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Core.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(LoginModel model)
        {
            string token = await userService.TryLoginUser(model);

            if (token == null)
                return new UnauthorizedResult();

            return Ok(token);
        }

        [HttpPost]
        public IActionResult Logout([FromQuery] int userId)
        {
            var stream = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.ReadToken(stream);
            var jwtSecurityToken = handler.ReadToken(stream) as JwtSecurityToken;


            return new OkResult();
        }
    }
}
