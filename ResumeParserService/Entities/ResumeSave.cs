namespace ResumeParserService.Entities
{
    public class ResumeSave
    {
        public int ID { get; set; }
        public CandidateDetail CandidateDetail  { get; set; }
        public string ResumePath { get; set; }
    }
}
