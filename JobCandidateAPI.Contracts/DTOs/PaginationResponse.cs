using JobCandidateAPI.Contracts.Candidates;

namespace JobCandidateAPI.Contracts.DTOs
{
    /// <summary>
    /// Represents the response for retrieving all candidates with pagination support.
    /// </summary>
    public class PaginationResponse
    {
        public Task<List<CandidateResponse>> Data { get; set; }
        public int RecordTotal { get; set; }
        public int RecordFiltred { get; set; }
    }
}
