using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatApp.Data.Entities.Common
{
    [Table("roles")]
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }
    }
}
