using System.Threading.Tasks;
using ChatApp.Common.ViewModels;
using ChatApp.Models.Common;

namespace ChatApp.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDTO model);
        Task RegisterUserAsync(UserRegisterDTO registerDTO);
        Task<bool> CheckIfTokenValid(string jwtToken);
    }
}
