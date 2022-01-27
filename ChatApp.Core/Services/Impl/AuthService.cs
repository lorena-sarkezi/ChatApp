using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Core.Helpers;
using ChatApp.Core.Services.Interfaces;
using ChatApp.Data.Entities;
using ChatApp.Data.Entities.Common;
using ChatApp.Data.Interfaces;
using ChatApp.Models.Common;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace ChatApp.Core.Services.Impl
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration Configuration;

        private readonly string _clientSecret;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            this.Configuration = configuration;

            _clientSecret = Configuration["ClientSecret"];
        }

        public async Task<string> LoginAsync(LoginDTO model)
        {
            string password = Base64.Base64Decode(model.Password);

            User user = await _userRepository.GetByUsernameAsync(model.Username);

            if (user == null) return null;

            byte[] saltedPasswordByteArr = KeyDerivation.Pbkdf2(password, Encoding.ASCII.GetBytes(user.PasswordSalt), KeyDerivationPrf.HMACSHA256, 1000, 64);

            if (Encoding.ASCII.GetString(saltedPasswordByteArr) != user.Password)
                return null;

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_clientSecret);

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
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_clientSecret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userIdClaim = jwtToken.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
                    
                if(userIdClaim == null)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                // return null if validation fails
                return false;
            }
        }
    }
}
