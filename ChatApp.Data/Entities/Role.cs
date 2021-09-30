using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatApp.Models.Database
{
    [Table("roles", Schema ="chat")]
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }
    }
}
