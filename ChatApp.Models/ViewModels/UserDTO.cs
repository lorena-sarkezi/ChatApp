using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Common.ViewModels
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
