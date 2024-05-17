namespace JobCandidateAPI.Contracts.Candidates
{
    /// <summary>
    /// Represents a request to create or update a candidate.
    /// </summary>
    public class CandidateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime PreferredCallTime { get; set; }
        public string LinkedIn_Profile_Url { get; set; }
        public string Github_Profile_Url { get; set; }
        public string Comment { get; set; }
    };
}
