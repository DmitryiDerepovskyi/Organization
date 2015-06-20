using FluentValidation.Attributes;
using Orgainzation.Web.Models.ValidatorView;

namespace Orgainzation.Web.Models
{
    [Validator(typeof(DepartmentViewModelValidator))]
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}