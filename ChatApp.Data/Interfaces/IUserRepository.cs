using System.Threading.Tasks;
using ChatApp.Models.Database;

namespace ChatApp.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(long userId);
        Task<User> GetUserByUsername(string username);
    }
}
