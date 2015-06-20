using FluentValidation;
using Organization.BusinessLogic.Validators;

namespace Orgainzation.Web.Models.ValidatorView
{
    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(p => p.ContactName)
                 .NotEmpty().WithMessage("Field cant't be empty!")
                 .Matches(PatternsRegex.Name);
            RuleFor(p => p.Phone)
               .NotEmpty().WithMessage("Field cant't be empty!")
               .Matches(PatternsRegex.Phone);
            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Field cant't be empty!");
        }
    }
}