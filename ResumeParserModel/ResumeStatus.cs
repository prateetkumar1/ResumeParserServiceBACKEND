using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResumeParserModel
{
    public class ResumeStatus
    {
        public int ID { get; set; }
        
        [Required]
        public string StatusName { get; set; }

        [Required]
        [MinLength(5)]
        public string StatusCode { get; set; }
    }
}
