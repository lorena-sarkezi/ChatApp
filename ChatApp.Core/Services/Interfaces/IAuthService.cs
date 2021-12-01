using System.Threading.Tasks;
using ChatApp.Models.Common;

namespace ChatApp.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDTO model);
        Task<bool> CheckIfTokenValid(string jwtToken);
    }
}
