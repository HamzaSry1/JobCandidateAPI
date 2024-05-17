using JobCandidateAPI.Contracts.DTOs;
using JobCandidateAPI.Models;

namespace JobCandidateAPI.Repository.Candidates
{
    public interface ICandidateRepository
    {
        Task<PaginationResponse> GetAllAsync(PaginationRequest pagination);
        Task<Candidate> GetByEmailAsync(string email);
        Task<Candidate> CreateAsync(Candidate candidate);
        Task<Candidate> UpdateAsync(Candidate candidate);
        Task<Candidate> DeleteAsync(Candidate candidate);
        Task<Candidate> DeleteAsync(string email);
    }
}
