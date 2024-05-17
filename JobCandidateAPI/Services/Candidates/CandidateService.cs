using JobCandidateAPI.Contracts.DTOs;
using JobCandidateAPI.Models;
using JobCandidateAPI.Repository.Candidates;

namespace JobCandidateAPI.Services.Candidates
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository repository;
        public CandidateService(ICandidateRepository repository)
            => this.repository = repository;

        public async Task<Candidate> CreateAsync(Candidate candidate)
            => await repository.CreateAsync(candidate);
        public async Task<Candidate> DeleteAsync(Candidate candidate)
            => await repository.DeleteAsync(candidate);
        public async Task<Candidate> DeleteAsync(string email)
            => await repository.DeleteAsync(email);
        public async Task<PaginationResponse> GetAllAsync(PaginationRequest pagination)
           => await repository.GetAllAsync(pagination);
        public async Task<Candidate> GetByEmailAsync(string email)
            => await repository.GetByEmailAsync(email);
        public async Task<Candidate> UpdateAsync(Candidate candidate)
            => await repository.UpdateAsync(candidate);
    }
}
