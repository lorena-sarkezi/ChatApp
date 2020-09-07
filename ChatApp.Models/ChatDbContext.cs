using ChatApp.Models.Common;
using ChatApp.Models.Database;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions options) : base(options)
        {
            
        }

        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set;  }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
    }
}
