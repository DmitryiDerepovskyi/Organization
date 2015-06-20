using System;
using FluentValidation;

namespace Orgainzation.Web.Models.ValidatorView
{
    public class EquipmentViewModelValidator : AbstractValidator<EquipmentViewModel>
    {
        public EquipmentViewModelValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .Matches(@"\w+");
            RuleFor(e => e.PurchaseDate)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .LessThan(DateTime.Now);
        }
    }
}