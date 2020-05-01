using ChatApp.Core.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Core.Data
{
    public class ChatDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ChatDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            operationalStoreOptions.Value.DefaultSchema = "chat_app";
        }

    }
}
