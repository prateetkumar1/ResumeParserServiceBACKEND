using AutoMapper;
using ResumeParserService.Context;
using ResumeParserCore.Helper;
using ResumeParserModel;
using ResumeParserService.Entities;
using System.Collections.Generic;
using ResumeParserService.ViewModels;

namespace ResumeParserService.Services
{
    public interface IResumeStatusService
    {
        IEnumerable<Entities.ResumeStatus> GetAll();
        Entities.ResumeStatus GetById(int id);
        void Create(ResumeStatusViewModel status);
        void Update(Entities.ResumeStatus status);
        void Delete(int id);
    }
    public class ResumeStatusService : IResumeStatusService
    {
        AppDBContext _DBcontext;
        IMapper _mapper;
        public ResumeStatusService(AppDBContext DBcontext, IMapper mapper)
        {
            _DBcontext = DBcontext;
            _mapper = mapper;
        }
        public void Create(ResumeStatusViewModel status)
        {
            var resumeStatus = _mapper.Map<Entities.ResumeStatus>(status);
            _DBcontext.ResumeStatuses.Add(resumeStatus);
            _DBcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Entities.ResumeStatus> GetAll()
        {
            return _DBcontext.ResumeStatuses;
        }

        public Entities.ResumeStatus GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Entities.ResumeStatus status)
        {
            throw new System.NotImplementedException();
        }

        private Entities.ResumeStatus GetResumeStatus(int id)
        {
            var resumeStatus = _DBcontext.ResumeStatuses.Find(id);
            if(resumeStatus == null)
            {
                throw new KeyNotFoundException("Resume status not found");
            }
            return resumeStatus;
        }
    }
}
