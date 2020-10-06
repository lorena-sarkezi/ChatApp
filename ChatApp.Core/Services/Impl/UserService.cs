using ChatApp.Core.Helpers;
using ChatApp.Core.Services.Interfaces;
using ChatApp.Models;
using ChatApp.Models.Common;
using ChatApp.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Data.SqlTypes;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace ChatApp.Core.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly ChatDbContext chatDbContext;
        private readonly IConfiguration Configuration;

        public UserService(ChatDbContext chatDbContext, IConfiguration configuration)
        {
            this.chatDbContext = chatDbContext;
            this.Configuration = configuration;
        }

        public string TryLoginUser(LoginModel model)
        {
            string password = Base64.Base64Decode(model.Password);

            User user = chatDbContext.Users.FirstOrDefault(x => x.Username == model.Username);

            if (user == null) return null;

            byte[] saltedPasswordByteArr = KeyDerivation.Pbkdf2(password, Encoding.ASCII.GetBytes(user.PasswordSalt), KeyDerivationPrf.HMACSHA256, 1000, 64);

            if(Encoding.ASCII.GetString(saltedPasswordByteArr) != user.Password)
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
    }
}
