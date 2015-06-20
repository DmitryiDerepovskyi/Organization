using System;

namespace Organization.Core
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
