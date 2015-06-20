using System;

namespace Organization.Core
{
    public class Contract : BaseEntity
    {
        public DateTime ContractDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        public int DepartmentId { get; set; }
        public int CustomerId { get; set; }
    }
}
