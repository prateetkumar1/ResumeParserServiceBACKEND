using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserModel
{
    public class CandidateResumeTracker
    {
        public int ID { get; set; }
        public CandidateDetail CandidateDetail { get; set; }
        public ResumeStatus ResumeStatus { get; set; }
    }
}
