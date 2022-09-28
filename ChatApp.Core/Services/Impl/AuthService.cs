using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Common.ViewModels;
using ChatApp.Core.Exceptions.Registration;
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

            if (hashPassword(model.Password, user.PasswordSalt) != user.Password)
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

        public async Task RegisterUserAsync(UserRegisterDTO registerDTO)
        {
            if(registerDTO.Password != registerDTO.PasswordConfirm)
            {
                throw new RegistrationPasswordMatchException();
            }

            var passwordDecoded = Helpers.Base64.Base64Decode(registerDTO.Password);
            var salt = generatePasswordSalt();

            var hashedPassword = hashPassword(passwordDecoded, salt);

            var personEntity = new Person
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName
            };

            var username = string.Concat(removeDiacritics(registerDTO.FirstName).ToLower(), ".", removeDiacritics(registerDTO.LastName).ToLower());
            var userEntity = new User
            {
                Username = username,
                TimestampCreated = DateTime.Now,
                PasswordSalt = salt,
                Password = hashedPassword,
                Person = personEntity
            };

            await _userRepository.CreateUser(userEntity);
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

        private static string hashPassword(string password, string salt)
        {
            var passwordByteArr = KeyDerivation.Pbkdf2(password, Encoding.ASCII.GetBytes(salt), KeyDerivationPrf.HMACSHA256, 1000, 64);
            return Encoding.ASCII.GetString(passwordByteArr);
        }

        private static string generatePasswordSalt()
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                var guid = Guid.NewGuid().ToString();
                var guidBytes = Encoding.UTF8.GetBytes(guid);

                // ComputeHash - returns byte array  
                byte[] bytesHashed = sha256Hash.ComputeHash(guidBytes);

                // Convert byte array to a string   
                return Encoding.ASCII.GetString(bytesHashed);
            }
        }

        // https://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
        private static string removeDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
    }
}
