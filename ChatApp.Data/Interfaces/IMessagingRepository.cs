using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Data.Entities.Chat;

namespace ChatApp.Data.Interfaces
{
    public interface IMessagingRepository
    {
        Task<List<Message>> GetMessagesByConversationIdAsync(int conversationId, int messageLimit = 25);

        Task<List<Conversation>> GetAllConversationsWithMessagesAsync(int messageLimit = 25);
    }
}
