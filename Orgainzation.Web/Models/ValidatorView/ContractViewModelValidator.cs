using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace Orgainzation.Web.Models.ValidatorView
{
    public class ContractViewModelValidator : AbstractValidator<ContractViewModel>
    {
        public ContractViewModelValidator()
        {
            RuleFor(c => c.ContractDate)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .LessThan(c => c.DueDate);
            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Field cant't be empty!")
                .GreaterThan(0);
            RuleFor(c => c.DueDate)
                .NotEmpty().WithMessage("Field cant't be empty!");
            RuleFor(c => c.DepartmentId)
                .NotEmpty().WithMessage("Field cant't be empty!");
            RuleFor(c => c.CustomerId)
                .NotEmpty().WithMessage("Field cant't be empty!");
        }
    }
}