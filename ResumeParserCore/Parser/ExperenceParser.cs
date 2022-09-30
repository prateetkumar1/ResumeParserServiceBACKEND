using System;
using System.Collections.Generic;
using System.Text;
using ResumeParserCore.Helper;
using ResumeParserModel;

namespace ResumeParserCore.Parser
{
    public class ExperenceParser : IParser
    {
        public void Parse(Section section, ResumeDetails resume)
        {
            foreach (var line in section.Content)
            {
                // var indexOfColon = line.IndexOf(':');
                //var skills = indexOfColon > -1 ? line.Substring(indexOfColon + 1) : line;
                // var elements = skills.Split(',');
                //resume.Skills.AddRange(s.Select(e => e.Trim()));
                resume.WorkExperience.Add(line);
            }
        }
    }
}
