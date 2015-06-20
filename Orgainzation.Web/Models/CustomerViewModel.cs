using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Orgainzation.Web.Models.ValidatorView;

namespace Orgainzation.Web.Models
{
    [Validator(typeof(CustomerViewModelValidator))]
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}