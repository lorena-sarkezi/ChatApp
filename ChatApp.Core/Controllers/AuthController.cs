using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using ChatApp.Core.Services.Interfaces;
using ChatApp.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace ChatApp.Core.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            this.userService = userService;
            this.authService = authService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(LoginDTO model)
        {
            string token = await authService.LoginAsync(model);

            if (token == null)
                return new UnauthorizedResult();

            return Ok(token);
        }

        [HttpGet("validate")]
        public async Task<IActionResult> ValidateToken(string token)
        {
            try
            {
                StringValues authHeader = new StringValues();
                bool success = HttpContext.Request.Headers.TryGetValue("Authorization", out authHeader);

                if (success)
                {
                    bool isTokenValid = await authService.CheckIfTokenValid(authHeader.ToString());
                    if (!isTokenValid) return Unauthorized();

                    return Ok();
                }

                return Unauthorized();
            }
            catch (ArgumentNullException)
            {
                return Unauthorized();
            }
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
