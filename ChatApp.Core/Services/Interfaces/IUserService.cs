using System.Threading.Tasks;
using ChatApp.Models.Common;

namespace ChatApp.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> TryLoginUser(LoginDTO model);
        Task<bool> CheckIfTokenValid(string jwtToken);
    }
}
