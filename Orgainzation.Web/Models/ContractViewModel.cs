using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation.Attributes;
using Orgainzation.Web.Models.ValidatorView;

namespace Orgainzation.Web.Models
{
    [Validator(typeof(ContractViewModelValidator))]
    public class ContractViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Contract date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ContractDate { get; set; }
        [Display(Name = "Due date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
    }
}