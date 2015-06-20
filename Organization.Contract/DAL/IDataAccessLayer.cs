using System.Collections.Generic;

namespace Organization.Contract.DAL
{
    public interface IDataAccessLayer<T>
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetByPrimaryKey(params object[] key);
    }
}
