﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatApp.Models.Database
{
    [Table("users", Schema = "chat")]
    public class User
    {
        [Required]
        public int Id { get; set; }

        [ForeignKey("Role")]
        public int? RoleId { get; set; }

        [Required, ForeignKey("person")]
        public int PersonId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordSalt { get; set; }

        [Required]
        public DateTime TimestampCreated { get; set; }

        public DateTime? TimestampModified { get; set; }



        public virtual Role Role { get; set; }
        public virtual Person Person { get; set; }
    }
}
