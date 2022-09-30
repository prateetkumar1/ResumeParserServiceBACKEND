using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResumeParserModel
{
    public class ResumeSave
    {
        public int ID { get; set; }
        [Required]
        public CandidateDetail CandidateDetail { get; set; }
        [Required]
        public string ResumePath { get; set; }

    }
}
