using JobCandidateAPI.Contracts.DTOs;
using JobCandidateAPI.Models;
using JobCandidateAPI.Repository.Candidates;

namespace JobCandidateAPI.Services.Candidates
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository repository;

        public CandidateService(ICandidateRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Candidate> CreateAsync(Candidate candidate)
        {
            return await repository.CreateAsync(candidate);
        }

        public async Task<Candidate> DeleteAsync(Candidate candidate)
        {
            return await repository.DeleteAsync(candidate);
        }

        public async Task<Candidate> DeleteAsync(string email)
        {
            return await repository.DeleteAsync(email);
        }

        public async Task<PaginationResponse> GetAllAsync(PaginationRequest pagination)
        {
            return await repository.GetAllAsync(pagination);
        }

        public async Task<Candidate> GetByEmailAsync(string email)
        {
            return await repository.GetByEmailAsync(email);
        }

        public async Task<Candidate> UpdateAsync(Candidate candidate)
        {
            return await repository.UpdateAsync(candidate);
        }
    }
}
