﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Core
{
    [Table("DeviceCodes", Schema = "chat_app")]
    public partial class DeviceCodes
    {
        [Key]
        [StringLength(200)]
        public string UserCode { get; set; }
        [Required]
        [StringLength(200)]
        public string DeviceCode { get; set; }
        [StringLength(200)]
        public string SubjectId { get; set; }
        [Required]
        [StringLength(200)]
        public string ClientId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime Expiration { get; set; }
        [Required]
        public string Data { get; set; }
    }
}
