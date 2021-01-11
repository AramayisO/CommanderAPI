using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Line { get; set; }

        [ForeignKey("Platform")]
        [Required]
        public int PlatformId { get; set; }
    }
}
