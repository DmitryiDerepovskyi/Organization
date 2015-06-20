using Organization.Contract.Core;

namespace Organization.Core
{
    public abstract class BaseEntity : IDbEntity
    {
        public int Id { get; set; }
    }
}
