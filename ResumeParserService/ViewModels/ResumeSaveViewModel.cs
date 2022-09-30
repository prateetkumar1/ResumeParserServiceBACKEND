using ResumeParserService.Entities;

namespace ResumeParserService.ViewModels
{
    public class ResumeSaveViewModel
    {
        public int ID { get; set; }
        public CandidateDetail CandidateDetail { get; set; }
        public string ResumePath { get; set; }
    }
}
