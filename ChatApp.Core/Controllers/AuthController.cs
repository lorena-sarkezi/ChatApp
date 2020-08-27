using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public IActionResult Authenticate(LoginModel model)
        {
            string token = userService.TryLoginUser(model);

            if (token == null)
                return new UnauthorizedResult();

            return Ok(token);
        }

        [HttpPost]
        public IActionResult Logout([FromQuery] int userId)
        {
            var stream = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = handler.ReadToken(stream) as JwtSecurityToken;

            

            return new OkResult();
        }
    }
}
