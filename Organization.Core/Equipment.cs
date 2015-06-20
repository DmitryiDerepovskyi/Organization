using System;

namespace Organization.Core
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? DepartmentId { get; set; }
    }
}
