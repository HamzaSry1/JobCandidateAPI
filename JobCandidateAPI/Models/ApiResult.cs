using JobCandidateAPI.Contracts.Candidates;
using JobCandidateAPI.ModelsValidator;
using System.Net;

namespace JobCandidateAPI.Contracts.Shared
{
    public class ApiResult
    {
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
        public CandidateResponse Data { get; set; }
        public List<CandidateValidator> ValidationErrors { get; set; }
    }
}
