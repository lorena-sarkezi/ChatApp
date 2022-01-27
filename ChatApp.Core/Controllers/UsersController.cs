using System.Threading.Tasks;
using ChatApp.Common.ViewModels;
using ChatApp.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Data.Entities;
using ChatApp.Core.Data;
using System.Collections.Generic;
using ChatApp.Core.Services.Interfaces;
using System.Linq;
using ChatApp.Data.Entities.Common;

namespace ChatApp.Core.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            User user = await userService.GetUserByIdAsync(id);
            if(user == null) return NoContent();

            return Ok(user.GetUserViewModel());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            List<User> userCollection = await userService.GetAllUsersAsync();
            if (userCollection.Count == 0) return NoContent();

            List<UserDTO> userDTOcollection = userCollection.Select(x => x.GetUserViewModel()).ToList(); 
            return Ok(userDTOcollection);
        }
    }
}
