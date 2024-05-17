using JobCandidateAPI.Contracts.Candidates;
using JobCandidateAPI.Contracts.DTOs;
using System.Net;

namespace JobCandidateAPI.Contracts.Shared
{
    /// <summary>
    /// Represents a result of an API operation.
    /// </summary>
    public class ApiResult
    {
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
        public CandidateResponse Data { get; set; }
        public List<FluentValidationErrors> ValidationErrors { get; set; }
    }
}
