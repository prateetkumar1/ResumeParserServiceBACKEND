using AutoMapper;
using ResumeParserModel;
using ResumeParserService.Entities;
using ResumeParserService.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ResumeParserModel.ResumeStatus, ResumeParserService.Entities.ResumeStatus>();
            CreateMap<ResumeParserModel.ResumeSave, ResumeParserService.Entities.ResumeSave>();
            // CreateMap<ResumeStatusViewModel, ResumeParserService.Entities.ResumeStatus>();
            CreateMap<CandidateViewModel, ResumeParserService.Entities.CandidateDetail>();
            CreateMap<CandidateResumeTrackerViewModel, ResumeParserService.Entities.CandidateResumeTracker>();
        }
    }
}
