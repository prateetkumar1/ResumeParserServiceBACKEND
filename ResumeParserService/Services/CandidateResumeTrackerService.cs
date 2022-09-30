using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResumeParserService.Context;
using ResumeParserService.Entities;
using ResumeParserService.ViewModels;
using System;
using System.Linq;

namespace ResumeParserService.Services
{
    public interface ICandidateResumeTrackerService
    {
        CandidateResumeTracker Create(CandidateResumeTrackerViewModel model);
    }
    public class CandidateResumeTrackerService : ICandidateResumeTrackerService
    {
        private AppDBContext _DBcontext;
        private IMapper _mapper;
        private readonly string IST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(("India Standard Time"))).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        public CandidateResumeTrackerService(AppDBContext DBcontext, IMapper mapper)
        {
            _DBcontext = DBcontext;
            _mapper = mapper;
        }

        public CandidateResumeTracker Create(CandidateResumeTrackerViewModel model)
        {
            // get candidate data
            var candidateResumeStatus = _DBcontext.CandidateResumeTrackers
            .Include(cd => cd.CandidateDetail)
            .Include(rs => rs.ResumeStatus).ToList();
            //validate candidateResumeStatus if the status already present
            if (candidateResumeStatus.Any(crt => crt.ResumeStatus.ID == model.ResumeStatus.ID && crt.CandidateDetail.ID == model.CandidateDetail.ID))
            {
                new System.Exception("Status already exist");
            }
            var candidateDetails = _DBcontext.CandidateDetails.Find(model.CandidateDetail.ID);
            var resumeStatuses = _DBcontext.ResumeStatuses.Find(model.ResumeStatus.ID);
            // map the model and save the data to DB
            CandidateResumeTracker crt = new CandidateResumeTracker();
            crt.CandidateDetail = candidateDetails;
            crt.ResumeStatus = resumeStatuses;
            crt.CreatedOn = IST;
            crt.CreatedBy = "USER";
            _DBcontext.CandidateResumeTrackers.Add(crt);
            _DBcontext.SaveChanges();
            return crt;
        }
    }
}
