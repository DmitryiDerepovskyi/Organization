using Organization.Contract.Core;

namespace Organization.Contract.BusinessLogic
{
    public interface IValidator<T> where T : class, IDbEntity
    {
        bool IsValid(T entity);
        bool IsExists(params object[] key);
    }
}
