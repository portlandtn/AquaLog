using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AquaLog.Core
{
    public class Log
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [MaxLength(255)]
        public string Notes { get; set; }
        public virtual Measurement Measurement { get; set; }

    }
}