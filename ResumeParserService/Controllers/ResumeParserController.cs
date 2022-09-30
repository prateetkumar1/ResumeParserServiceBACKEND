using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResumeParserCore.Processor;
using ResumeParserModel;
using ResumeParserService.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeParserService.Controllers
{
    [Route("api/Resume")]
    [Produces("application/json")]
    public class ResumeParserController : ControllerBase
    {

        private readonly ILogger<ResumeParserController> _logger;
        private readonly IProcessor _processor;
        AppDBContext _DBcontext;

        public ResumeParserController(ILogger<ResumeParserController> logger, IProcessor processor, AppDBContext DBcontext)
        {
            _logger = logger;
            _processor = processor;
            _DBcontext = DBcontext;
        }

        [Route("~/api/Parse")]
        [HttpGet]
        public IList<Resume> Get()
        {

            var files = Directory.GetFiles("Resumes").Select(Path.GetFullPath);
            var fileName = "";
            var resumeDatas = _DBcontext.ResumeSaves.Include(r => r.CandidateDetail).OrderBy(rs => rs.ID);
            var resumeStatus = _DBcontext.ResumeStatuses.FirstOrDefault();
            var candidateResumeStatus = _DBcontext.CandidateResumeTrackers
                .Include(cd => cd.CandidateDetail)
                .Include(rs => rs.ResumeStatus).ToList();
            //.Where(crt => crt.CandidateDetail.ID == 27).OrderByDescending(c => c.ID);           
            List<Resume> resumes = new List<Resume>();
            foreach (var file in files)
            {
                var output = _processor.Process(file);                
                resumes.Add(output);
                fileName = file.Split("\\").Last();
                foreach (var resumeData in resumeDatas)
                {
                    var rd = resumeData.ResumePath.ToString().Split("\\").Last();
                    if(fileName == rd)
                    {
                        // insert the candidate ID
                        output.Details.ID = resumeData.CandidateDetail.ID;
                        // insert the candidate name
                        output.Details.FirstName = resumeData.CandidateDetail.CandidateName;
                        
                        // get the resume status as per candidate
                        var a = candidateResumeStatus.Where(crt => crt.CandidateDetail.ID == resumeData.CandidateDetail.ID).OrderByDescending(c => c.ID).FirstOrDefault();
                        ResumeStatus rsts = new ResumeStatus();
                        // allocate the resume status
                        if (a != null)
                        {
                            rsts.ID = a.ResumeStatus.ID;
                            rsts.StatusName = a.ResumeStatus.StatusName;
                            rsts.StatusCode = a.ResumeStatus.StatusCode;
                        } else
                        {
                            rsts.ID = resumeStatus.ID;
                            rsts.StatusName = resumeStatus.StatusName;
                            rsts.StatusCode = resumeStatus.StatusCode;
                        }                        
                        output.Details.ResumeStatus = rsts;
                    }
                }
            }
            return resumes;
           
        }
    }
}
