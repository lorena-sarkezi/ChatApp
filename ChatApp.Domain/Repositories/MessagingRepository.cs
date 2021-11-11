using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Data;
using ChatApp.Data.Interfaces;

namespace ChatApp.Domain.Repositories
{
    public class MessagingRepository : IMessagingRepository
    {
        private readonly ChatDbContext chatDbContext;

        public MessagingRepository(ChatDbContext chatDbContext)
        {
            this.chatDbContext = chatDbContext;
        }
    }
}
