﻿using System.Threading.Tasks;
using ChatApp.Data;
using ChatApp.Data.Interfaces;
using ChatApp.Models.Database;
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

        public async Task<User> GetUserById(long userId)
        {
            return await _chatDbContext.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _chatDbContext.Users.SingleOrDefaultAsync(x => x.Username == username);
        }
    }
}
