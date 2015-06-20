using FluentValidation;
using Organization.BusinessLogic.Validators;

namespace Orgainzation.Web.Models.ValidatorView
{
    public class EmployeeViewModelValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeViewModelValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .Matches(PatternsRegex.Name);
            RuleFor(p => p.LastName)
               .NotEmpty().WithMessage("Field cant't be empty!")
               .Matches(PatternsRegex.Name);
            RuleFor(p => p.Phone)
               .NotEmpty().WithMessage("Field cant't be empty!")
               .Matches(PatternsRegex.Phone);
            RuleFor(p => p.Salary)
               .NotEmpty().WithMessage("Field cant't be empty!")
               .GreaterThan(0);
            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("Field cant't be empty!");
        }
    }
}