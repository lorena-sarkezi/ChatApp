using ChatApp.Models.Common;
using ChatApp.Models.Domain;
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
    public class ChatDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ChatDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            operationalStoreOptions.Value.DefaultSchema = "chat_app";
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    }
}
