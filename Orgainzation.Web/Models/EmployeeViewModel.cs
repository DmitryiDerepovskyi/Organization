using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Orgainzation.Web.Models.ValidatorView;

namespace Orgainzation.Web.Models
{
    [Validator(typeof(EmployeeViewModelValidator))]
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public decimal Salary { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}