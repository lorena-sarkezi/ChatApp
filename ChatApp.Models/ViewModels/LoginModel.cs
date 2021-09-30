using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Models.Common
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Rememeber { get; set; }
        //public string ReturnUrl { get; set; }
    }
}
