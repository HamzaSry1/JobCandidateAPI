namespace JobCandidateAPI.Contracts.DTOs
{
    /// <summary>
    /// Represents validation errors returned by FluentValidation.
    /// </summary>
    public class FluentValidationErrors
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
