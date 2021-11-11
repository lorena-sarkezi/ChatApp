using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data.Entities
{
    [Table("messages", Schema = "chat")]
    public class Message
    {
        [Required]
        public int MessageId { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        public string MessageContent { get; set; }

        [Required]
        public DateTime TimestampCreated { get; set; }


        public virtual User User { get; set; }

    }
}
