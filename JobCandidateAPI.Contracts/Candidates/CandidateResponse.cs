namespace JobCandidateAPI.Contracts.Candidates
{
    public record CandidateResponse(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Email,
        string PreferredCallTime,
        string LinkedIn_Profile_Url,
        string Github_Profile_Url,
        string Comment
    );
}
