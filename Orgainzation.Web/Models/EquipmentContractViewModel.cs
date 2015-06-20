using System.ComponentModel.DataAnnotations;

namespace Orgainzation.Web.Models
{
    public class EquipmentContractViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Equipment")]
        public int EquipmentId { get; set; }
        [Display(Name = "Contract Id")]
        public int ContractId { get; set; }
    }
}