using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Data.Entities.Common;
using ChatApp.Data.Entities.Enum;

namespace ChatApp.Data.Entities.Chat
{
    [Table("messages", Schema = "chat")]
    public class Message
    {
        [Required]
        public int MessageId { get; set; }

        [Required, ForeignKey("SenderUser")]
        public int SenderUserId { get; set; }

        [Required, ForeignKey("Conversation")]
        public int ConversationId { get; set; }

        [ForeignKey("Media")]
        public int MediaId { get; set; }

        [Required]
        public MessageTypeEnum MessageTypeId { get; set; }

        public string MessageContent { get; set; }

        [Required]
        public DateTime TimestampCreated { get; set; }


        public virtual User SenderUser { get; set; }

        public virtual Conversation Conversation { get; set; }

        public virtual Media Media { get; set; }

    }
}
