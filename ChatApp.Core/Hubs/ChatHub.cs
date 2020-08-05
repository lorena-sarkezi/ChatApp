using ChatApp.Core.Data;
using ChatApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Core.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {
        private readonly ChatDbContext chatDbContext;

        public ChatHub(ChatDbContext chatDbContext)
        {
            this.chatDbContext = chatDbContext;
        }

    }
}
