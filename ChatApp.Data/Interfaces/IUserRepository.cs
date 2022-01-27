using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApp.Data.Entities;
using ChatApp.Data.Entities.Common;

namespace ChatApp.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(long userId);
        Task<User> GetByUsernameAsync(string username);
        Task<List<User>> GetAllAsync();
    }
}
