namespace ResumeParserService.Entities.AbstractClasses
{
    public abstract class EntryLog
    {
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
