using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Orgainzation.Web.Models.ValidatorView;

namespace Orgainzation.Web.Models
{
    [Validator(typeof(EquipmentViewModelValidator))]
    public class EquipmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        public int? DepartmentId { get; set; }
    }
}