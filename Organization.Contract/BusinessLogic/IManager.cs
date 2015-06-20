using System.Collections.Generic;
using Organization.Contract.Core;

namespace Organization.Contract.BusinessLogic
{
    public interface IManager<T> where T : class, IDbEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(params object[] keys);
        T GetByPrimaryKey(params object[] keys);
        IEnumerable<T> GetAll();
    }
}
