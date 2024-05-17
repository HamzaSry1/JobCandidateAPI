namespace JobCandidateAPI.Contracts.Const
{
    public static class Messages
    {
        public const string FieldNotEmpty = " must not be empty.";
        public const string InvalidEmailFormat = "Invalid email format.";
        public const string CandidateCreatedSuccessfully = "Candidate information has been added successfully.";
        public const string CandidateBadRequest = "Bad Request: Invalid input data. Please check your request parameters.";
        public const string CandidateUpdatedSuccessfully = "Candidate information has been updated successfully.";
        public const string CandidateNotFound = "Not Found: Candidate information with provided email does not exist.";
        public const string SqlConnectionException = "The SQL connection string is not found in the configuration.";
    }
}
