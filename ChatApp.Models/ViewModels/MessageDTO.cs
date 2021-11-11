using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Common.ViewModels
{
    public class MessageDTO
    {
        public int SenderUserId { get; set; }
        public int RecepientUserId { get; set; }
        public string Message { get; set; }
    }
}
