using FluentValidation;
using JobCandidateAPI.Models;
using JobCandidateAPI.Contracts.Const;

namespace JobCandidateAPI.ModelsValidator
{
    public class CandidateValidator : AbstractValidator<Candidate>
    {
        public CandidateValidator()
        {
            RuleFor(candidate => candidate.FirstName)
                .NotEmpty().WithMessage($"{nameof(Candidate.FirstName)}{Messages.FieldNotEmpty}");

            RuleFor(candidate => candidate.LastName)
                .NotEmpty().WithMessage($"{nameof(Candidate.LastName)}{Messages.FieldNotEmpty}");

            RuleFor(candidate => candidate.Email)
                .NotEmpty().WithMessage($"{nameof(Candidate.Email)}{Messages.FieldNotEmpty}")
                .EmailAddress().WithMessage(Messages.InvalidEmailFormat);

            RuleFor(candidate => candidate.Comment)
                .NotEmpty().WithMessage($"{nameof(Candidate.Comment)}{Messages.FieldNotEmpty}");
        }
    }
}
