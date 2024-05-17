using FluentValidation;
using JobCandidateAPI.Contracts.Const;
using JobCandidateAPI.Contracts.Candidates;

namespace JobCandidateAPI.ModelsValidator
{
    public class CandidateValidator : AbstractValidator<CandidateRequest>
    {
        public CandidateValidator()
        {
            RuleFor(candidate => candidate.FirstName)
                .NotEmpty().WithMessage($"{nameof(CandidateRequest.FirstName)}{Messages.FieldNotEmpty}");

            RuleFor(candidate => candidate.LastName)
                .NotEmpty().WithMessage($"{nameof(CandidateRequest.LastName)}{Messages.FieldNotEmpty}");

            RuleFor(candidate => candidate.Email)
                .NotEmpty().WithMessage($"{nameof(CandidateRequest.Email)}{Messages.FieldNotEmpty}")
                .EmailAddress().WithMessage(Messages.InvalidEmailFormat);

            RuleFor(candidate => candidate.Comment)
                .NotEmpty().WithMessage($"{nameof(CandidateRequest.Comment)}{Messages.FieldNotEmpty}");
        }
    }
}
