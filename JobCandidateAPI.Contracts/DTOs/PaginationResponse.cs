using JobCandidateAPI.Contracts.Candidates;

namespace JobCandidateAPI.Contracts.DTOs
{
    public class PaginationResponse
    {
        public Task<List<CandidateResponse>> Data { get; set; }
        public int RecordTotal { get; set; }
        public int RecordFiltred { get; set; }
    }
}
