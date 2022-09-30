using ResumeParserService.Entities.AbstractClasses;

namespace ResumeParserService.Entities
{
    public class CandidateResumeTracker:EntryLog
    {
        public int ID { get; set; }
        public CandidateDetail CandidateDetail { get; set; }
        public ResumeStatus ResumeStatus { get; set; }
    }
}
