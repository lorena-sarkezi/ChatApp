using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Core.Helpers;
using ChatApp.Core.Services.Interfaces;
using ChatApp.Data.Interfaces;
using ChatApp.Models.Common;
using ChatApp.Models.Database;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ChatApp.Core.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration Configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            this.Configuration = configuration;
        }

        public async Task<string> TryLoginUser(LoginDTO model)
        {
            string password = Base64.Base64Decode(model.Password);

            User user = await _userRepository.GetUserByUsername(model.Username);

            if (user == null) return null;

            byte[] saltedPasswordByteArr = KeyDerivation.Pbkdf2(password, Encoding.ASCII.GetBytes(user.PasswordSalt), KeyDerivationPrf.HMACSHA256, 1000, 64);

            if (Encoding.ASCII.GetString(saltedPasswordByteArr) != user.Password)
                return null;

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(Configuration["ClientSecret"]);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, $"{user.Person.FirstName} {user.Person.LastName}"),
                new Claim(ClaimTypes.Role, user.Role.RoleName)
            };

            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> CheckIfTokenValid(string token)
        {
            return true;
        }
    }
}
