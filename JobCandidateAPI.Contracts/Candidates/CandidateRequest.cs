namespace JobCandidateAPI.Contracts.Candidates
{
    public class CandidateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PreferredCallTime { get; set; }
        public string LinkedIn_Profile_Url { get; set; }
        public string Github_Profile_Url { get; set; }
        public string Commen { get; set; }
    };
}
