namespace Organization.Core
{
    public class Customer : BaseEntity
    {
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
