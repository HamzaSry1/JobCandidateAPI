namespace JobCandidateAPI.Contracts.DTOs
{
    /// <summary>
    /// Represents the request to retrieve all candidates with pagination support.
    /// </summary>
    public class PaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string OrderByDirection { get; set; }
    }
}
