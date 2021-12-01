using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApp.Data.Entities;
using ChatApp.Models.Common;

namespace ChatApp.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
    }
}
