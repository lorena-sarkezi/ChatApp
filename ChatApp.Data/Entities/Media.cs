using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data.Entities
{
    [Table("Messages", Schema = "chat")]
    public class Media
    {
        public int MediaId { get; set; }
        public int MessageId { get; set; }
        public int AzureBlobId { get; set; }
        public string FilePath { get; set; }    
        public DateTime TimestampCreated { get; set; }

        public virtual User User { get; set; }

    }
}
