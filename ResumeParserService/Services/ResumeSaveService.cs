using AutoMapper;
using ResumeParserService.Context;
using ResumeParserModel;
using ResumeParserService.Entities;
using System.Collections.Generic;
using ResumeParserService.ViewModels;
using Microsoft.AspNetCore.Http;

namespace ResumeParserService.Services
{
    public interface IResumeSaveService
    {
        void Create(IFormFile file, string dbPath);
    }
    public class ResumeSaveService : IResumeSaveService
    {
        AppDBContext _DBcontext;
        IMapper _mapper;
        public ResumeSaveService(AppDBContext DBcontext, IMapper mapper)
        {
            _DBcontext = DBcontext;
            _mapper = mapper;
        }

        public void Create(IFormFile file, string dbPath)
        {
            var candidate = _DBcontext.CandidateDetails.Find(int.Parse(file.Name));
            if (candidate == null)
            {
                throw new System.Exception("Candidate not found");
            }
            Entities.ResumeSave model = new Entities.ResumeSave();
            model.CandidateDetail = candidate;
            model.ResumePath = dbPath;
            _DBcontext.ResumeSaves.Add(model);
            _DBcontext.SaveChanges();
        }
    }
}
