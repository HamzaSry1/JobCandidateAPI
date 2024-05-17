using AutoMapper;
using JobCandidateAPI.Contracts.Candidates;
using JobCandidateAPI.Models;

namespace JobCandidateAPI.Contracts.Mapper
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CandidateResponse>().ReverseMap();
            CreateMap<CandidateRequest, Candidate>().ReverseMap();
        }
    }
}
