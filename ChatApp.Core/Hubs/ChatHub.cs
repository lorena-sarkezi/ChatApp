using System.Threading.Tasks;
using ChatApp.Common.ViewModels;
using ChatApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Core.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ChatDbContext chatDbContext;

        public ChatHub(ChatDbContext chatDbContext)
        {
            this.chatDbContext = chatDbContext;
        }

        public async Task SendMessageAllClients(MessageDTO chatMessage)
        {
            
            await Clients.All.SendAsync("ReceiveMessage", chatMessage);
        }
    }
}
