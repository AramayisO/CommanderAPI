﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Dtos
{
    public class PlatformCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
