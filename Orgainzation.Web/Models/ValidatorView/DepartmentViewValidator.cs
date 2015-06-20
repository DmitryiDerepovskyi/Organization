using FluentValidation;
using Organization.BusinessLogic.Validators;

namespace Orgainzation.Web.Models.ValidatorView
{
    public class DepartmentViewModelValidator : AbstractValidator<DepartmentViewModel>
    {
        public DepartmentViewModelValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .Length(2, 50).WithMessage("Name can't be that length!")
                .Matches(PatternsRegex.DepartmentName);
        }
    }
}