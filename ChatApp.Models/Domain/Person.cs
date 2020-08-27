using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatApp.Models.Domain
{
    [Table("persons", Schema ="chat")]
    public class Person
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int GenderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }



        public virtual Gender Gender { get; set; }
    }
}
