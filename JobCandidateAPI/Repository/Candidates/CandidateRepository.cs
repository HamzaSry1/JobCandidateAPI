using JobCandidateAPI.Contracts.Candidates;
using JobCandidateAPI.Contracts.DTOs;
using JobCandidateAPI.Data;
using JobCandidateAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateAPI.Repository.Candidates
{
    public abstract class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext dbContext;
        public CandidateRepository(AppDbContext context) => dbContext = context;

        public virtual async Task<Candidate> CreateAsync(Candidate candidate)
        {
            var result = await dbContext.AddAsync(candidate);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<Candidate> UpdateAsync(Candidate candidate)
        {
            dbContext.Entry(candidate).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return candidate;
        }

        public virtual async Task<Candidate> DeleteAsync(Candidate candidate)
        {
            var result = dbContext.Remove(candidate);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<Candidate> DeleteAsync(string email)
        {
            var data = await GetByEmailAsync(email);

            if (data is not null)
                return await DeleteAsync(data);

            return null;
        }

        public virtual async Task<Candidate> GetByEmailAsync(string email)
        {
            return await dbContext.Candidates
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public virtual async Task<PaginationResponse> GetAllAsync(PaginationRequest pagination)
        {
            var query = dbContext.Candidates.AsQueryable();

            var response = new PaginationResponse
            {
                RecordTotal = await query.CountAsync(),
            };

            if (pagination != null)
            {
                query = ApplyPagination(query, pagination);
            }

            response.RecordFiltred = await query.CountAsync();

            response.Data = query.Select(c => new CandidateResponse
            {
                Email = c.Email,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                PreferredCallTime = c.PreferredCallTime,
                LinkedIn_Profile_Url = c.LinkedIn_Profile_Url,
                Github_Profile_Url = c.Github_Profile_Url,
                Comment = c.Comment

            }).ToListAsync();

            return response;
        }
        private IQueryable<Candidate> ApplyPagination(IQueryable<Candidate> query, PaginationRequest pagination)
        {
            // Apply pagination
            query = query.Skip(((pagination?.PageNumber ?? 1) - 1) * (pagination?.PageSize ?? 5)).Take(pagination?.PageSize ?? 5);
            // Apply ordering
            if (!string.IsNullOrEmpty(pagination.OrderBy))
            {
                var orderByProperty = pagination.OrderBy.ToLower();
                query = orderByProperty switch
                {
                    "email" => pagination.OrderByDirection == "desc" ? query.OrderByDescending(e => e.Email) : query.OrderBy(e => e.Email),
                    "firstname" => pagination.OrderByDirection == "desc" ? query.OrderByDescending(e => e.FirstName) : query.OrderBy(e => e.FirstName),
                    "lastname" => pagination.OrderByDirection == "desc" ? query.OrderByDescending(e => e.LastName) : query.OrderBy(e => e.LastName),
                    "phonenumber" => pagination.OrderByDirection == "desc" ? query.OrderByDescending(e => e.PhoneNumber) : query.OrderBy(e => e.PhoneNumber),
                    "preferredcalltime" => pagination.OrderByDirection == "desc" ? query.OrderByDescending(e => e.PreferredCallTime) : query.OrderBy(e => e.PreferredCallTime),
                    "linkedin_profile_url" => pagination.OrderByDirection == "desc" ? query.OrderByDescending(e => e.LinkedIn_Profile_Url) : query.OrderBy(e => e.LinkedIn_Profile_Url),
                    "github_profile_url" => pagination.OrderByDirection == "desc" ? query.OrderByDescending(e => e.Github_Profile_Url) : query.OrderBy(e => e.Github_Profile_Url),
                    "comment" => pagination.OrderByDirection == "desc" ? query.OrderByDescending(e => e.Comment) : query.OrderBy(e => e.Comment),
                    _ => query
                };
            }

            return query;
        }
    }
}
