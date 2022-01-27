using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Data;
using ChatApp.Data.Entities.Chat;
using ChatApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace ChatApp.Domain.Repositories
{
    public class MessagingRepository : IMessagingRepository
    {
        private readonly ChatDbContext chatDbContext;

        public MessagingRepository(ChatDbContext chatDbContext)
        {
            this.chatDbContext = chatDbContext;
        }

        public async Task<List<Message>> GetMessagesByConversationIdAsync(int conversationId, int messageLimit = 25)
        {

            var messageQuery = chatDbContext.Messages
                                            .Where(x => x.ConversationId == conversationId);

            if (messageLimit > 0)
            {
                messageQuery.Take(messageLimit);
            }

            return await messageQuery.ToListAsync();
        }



        public async Task<List<Conversation>> GetAllConversationsWithMessagesAsync(int messageLimit = 25)
        {
            var test = chatDbContext.Conversations
                                          .IncludeFilter(x => x.Messages.Take(messageLimit));

            if (messageLimit > 0)
            {
                return await chatDbContext.Conversations
                                          .IncludeFilter(x => x.Messages.Take(messageLimit))
                                          .ToListAsync();
            }

            return await chatDbContext.Conversations
                                      .Include(x => x.Messages)
                                      .ToListAsync();
        }
    }
}
