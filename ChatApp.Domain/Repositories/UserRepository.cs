using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApp.Data;
using ChatApp.Data.Entities.Common;
using ChatApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Domain.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly ChatDbContext _chatDbContext;

        public UserRepository(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<User> GetByIdAsync(long userId)
        {
            return await _chatDbContext.Users.FindAsync(userId);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _chatDbContext.Users.SingleOrDefaultAsync(x => x.Username == username);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _chatDbContext.Users.ToListAsync();
        }
    }
}
