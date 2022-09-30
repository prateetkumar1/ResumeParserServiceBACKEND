using AutoMapper;
using ResumeParserService.Context;
using ResumeParserService.Entities;
using ResumeParserService.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ResumeParserService.Services
{
    public interface ICandidateService
    {
        IEnumerable<CandidateViewModel> GetAll();
        CandidateViewModel GetById(int id);
        CandidateDetail Create(CandidateViewModel model);
        void Update(CandidateViewModel model);
        void Delete(int id);
    }
    public class CandidateService : ICandidateService
    {
        AppDBContext _DBcontext;
        IMapper _mapper;
        public CandidateService(AppDBContext DBcontext, IMapper mapper)
        {
            _DBcontext = DBcontext;
            _mapper = mapper;
        }
        CandidateDetail ICandidateService.Create(CandidateViewModel model)
        {
            // validate the incomming model
            if (_DBcontext.CandidateDetails.Any(cd => cd.EmailID == model.EmailID))
            {
                throw new System.Exception("Candidate with the email " + model.EmailID + " already exist");
            }
            if (_DBcontext.CandidateDetails.Any(cd => cd.MobileNumber == model.MobileNumber))
            {
                throw new System.Exception("Candidate with the phone " + model.MobileNumber + " already exist");
            }
            var candidate = _mapper.Map<CandidateDetail>(model);
            _DBcontext.CandidateDetails.Add(candidate);
            _DBcontext.SaveChanges();
            return candidate;
        }

        void ICandidateService.Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<CandidateViewModel> ICandidateService.GetAll()
        {
            throw new System.NotImplementedException();
        }

        CandidateViewModel ICandidateService.GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        void ICandidateService.Update(CandidateViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
