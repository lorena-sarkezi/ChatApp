﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Data.Entities.Common;

namespace ChatApp.Data.Entities.Chat
{
    [Table("Messages", Schema = "chat")]
    public class Media
    {
        public int MediaId { get; set; }
        public int AzureBlobId { get; set; }
        public string FilePath { get; set; }    
        public DateTime TimestampCreated { get; set; }

    }
}
