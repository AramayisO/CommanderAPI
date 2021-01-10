﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }
        [Required]
        [MaxLength(255)]
        public string Line { get; set; }
        [Required]
        [MaxLength(255)]
        public string Platform { get; set; }
    }
}
