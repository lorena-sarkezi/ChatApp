using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Data.Entities.Enum;

namespace ChatApp.Data.Entities.Chat
{
    [Table("Conversations", Schema = "chat")]
    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ConversationTypeEnum ConversationTypeId { get; set; }

        [Required]
        public DateTime LatestMessageTimestamp { get; set; }

        [Required]
        public DateTime TimestampCreated { get; set; }


        [InverseProperty("ConversationId")]
        public virtual List<Message> Messages { get; set; }


    }
}
