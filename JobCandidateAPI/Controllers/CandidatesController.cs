using JobCandidateAPI.Contracts.Candidates;
using JobCandidateAPI.Contracts.Const;
using JobCandidateAPI.Contracts.DTOs;
using JobCandidateAPI.Contracts.Shared;
using JobCandidateAPI.Models;
using JobCandidateAPI.ModelsValidator;
using JobCandidateAPI.Services.Candidates;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using AutoMapper;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace JobCandidateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService service;
        private readonly IMapper mapper;

        public CandidatesController(ICandidateService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        #region CRUD

        [HttpPost("GetAllAsync")]
        public async Task<PaginationResponse> GetAllAsync(PaginationRequest request)
        {
            return await service.GetAllAsync(request);
        }

        [HttpGet("GetByEmailAsync/{email}")]
        public async Task<ApiResult> GetByEmailAsync(string email)
        {
            var candidate = await service.GetByEmailAsync(email);

            if (candidate == null)
                return new ApiResult { Status = HttpStatusCode.NotFound, Message = Messages.CandidateNotFound };

            var response = mapper.Map<CandidateResponse>(candidate);

            return new ApiResult { Status = HttpStatusCode.OK, Data = response, Message = Messages.CandidateFound };
        }

        [HttpPost("CreateAsync")]
        public async Task<ApiResult> CreateAsync(CandidateRequest request)
        {
            // request Validation 
            var validation = Validation(request);
            if (validation.Any())
                return new ApiResult { ValidationErrors = validation, Status = HttpStatusCode.BadRequest };

            // search for the candidate by Email , if exists move into Update 
            var existingCandidate = await service.GetByEmailAsync(request.Email);
            if (existingCandidate != null)
                return await UpdateAsync(request);

            // map the CandidateRequest into Candidate
            var candidate = mapper.Map<Candidate>(request);

            var createdCandidate = await service.CreateAsync(candidate);
            if (createdCandidate is null)
                return new ApiResult { Status = HttpStatusCode.BadRequest, Message = Messages.CandidateBadRequest };

            // map the Candidate into CandidateResponse
            var response = mapper.Map<CandidateResponse>(createdCandidate);

            return new ApiResult { Status = HttpStatusCode.Created, Data = response, Message = Messages.CandidateCreatedSuccessfully };
        }

        [HttpPut("UpdateAsync")]
        public async Task<ApiResult> UpdateAsync(CandidateRequest request)
        {
            // request Validation 
            var validation = Validation(request);
            if (validation.Any())
                return new ApiResult { ValidationErrors = validation, Status = HttpStatusCode.BadRequest };

            // map the CandidateRequest into Candidate
            var candidate = mapper.Map<Candidate>(request);

            var updatedCandidate = await service.UpdateAsync(candidate);

            if (updatedCandidate is null)
                return new ApiResult { Status = HttpStatusCode.NotFound, Message = Messages.CandidateNotFound };

            // map the Candidate into CandidateResponse
            var response = mapper.Map<CandidateResponse>(updatedCandidate);

            return new ApiResult { Status = HttpStatusCode.OK, Data = response, Message = Messages.CandidateUpdatedSuccessfully };
        }

        [HttpDelete("DeleteAsync/{email}")]
        public async Task<ApiResult> DeleteAsync(string email)
        {
            var deletedCandidate = await service.DeleteAsync(email);

            if (deletedCandidate is null)
                return new ApiResult { Status = HttpStatusCode.NotFound, Message = Messages.CandidateNotFound };

            // map the Candidate into CandidateResponse
            var response = mapper.Map<CandidateResponse>(deletedCandidate);

            return new ApiResult { Status = HttpStatusCode.OK, Data = response, Message = Messages.CandidateDeletedSuccessfully };
        }

        #endregion CRUD

        #region Validation

        private List<FluentValidationErrors> Validation(CandidateRequest request)
        {
            var validationRules = new CandidateValidator();
            var validationResult = validationRules.Validate(request);

            return validationResult.Errors.Select(err => new FluentValidationErrors
            {
                PropertyName = err.PropertyName,
                ErrorMessage = err.ErrorMessage
            }).ToList();
        }

        #endregion Validation
    }
}
