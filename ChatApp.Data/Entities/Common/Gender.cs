﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatApp.Data.Entities.Common
{
    [Table("genders",Schema ="chat")]
    public class Gender
    {
        public int Id { get; set; }
        public int GenderName { get; set; }
    }
}
