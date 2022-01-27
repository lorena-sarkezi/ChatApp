using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Data.Entities.Common;

namespace ChatApp.Data.Entities.Chat
{
    [Table("ConversationParticipants", Schema = "chat")]
    public class ConversationParticipant
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Conversation")]
        public int ConversationId { get; set;}

        public User User;
        public Conversation Conversation;

    }
}
