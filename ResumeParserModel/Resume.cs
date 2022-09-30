using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserModel
{

    public enum Catagory
    {
        Cloud,
        Java,
        FullStack,
        Net
    }
    public class Resume
        {
           public Catagory Catagory { get; set; }
           public ResumeDetails Details { get; set; }
        }
    public class ResumeDetails
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumbers { get; set; }
       // public string SummaryDescription { get; set; }
        public List<string> Skills { get; set; }
        public List<Project> Projects { get; set; }
        public List<string> SocialProfiles { get; set; }
        public List<Education> Educations { get; set; }
        public List<string> WorkExperience { get; set; }
        public string FileLocation { get; set; }
        public ResumeStatus ResumeStatus { get; set; }

        public ResumeDetails()
        {
            Skills = new List<string>();
            Projects = new List<Project>();
            SocialProfiles = new List<string>();
            Educations = new List<Education>();
            WorkExperience = new List<string>();
        }
    }
}
