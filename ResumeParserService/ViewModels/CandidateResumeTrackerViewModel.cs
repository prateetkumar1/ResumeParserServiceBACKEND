using ResumeParserModel;

namespace ResumeParserService.ViewModels
{
    public class CandidateResumeTrackerViewModel
    {
        public int ID { get; set; }
        public CandidateDetail CandidateDetail { get; set; }
        public ResumeStatus ResumeStatus { get; set; }
    }
}
