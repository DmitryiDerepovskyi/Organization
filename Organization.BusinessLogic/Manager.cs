using System;
using System.Collections.Generic;
using System.Linq;
using Organization.Contract.BusinessLogic;
using Organization.Contract.DAL;
using Organization.Core;

namespace Organization.BusinessLogic
{
    public class Manager<T> : IManager<T> where T : BaseEntity
    {
        private readonly IValidator<T> _validator;
        private readonly IDataAccessLayer<T> _dataAccessLayer;
        public Manager(IValidator<T> validator, IDataAccessLayer<T> dataAccessLayer)
        {
            _validator = validator;
            _dataAccessLayer = dataAccessLayer;
        }

        public void Add(T entity)
        {
            if (!_validator.IsValid(entity))
                throw new Exception("Entity is not valid");
            _dataAccessLayer.Create(entity);
        }

        public void Update(T entity)
        {
            if (!_validator.IsValid(entity))
                throw new Exception("Entity is not valid");
            _dataAccessLayer.Update(entity);
        }

        public void Remove(params object[] keys)
        {
            if (!_validator.IsExists(keys))
                throw new Exception("Entity is not valid");
            var entity = _dataAccessLayer.GetByPrimaryKey(keys);
            _dataAccessLayer.Delete(entity);
        }

        public T GetByPrimaryKey(params object[] keys)
        {
            if (!_validator.IsExists(keys))
                throw new Exception("Entity is not exists");
            return _dataAccessLayer.GetByPrimaryKey(keys);
        }

        public IEnumerable<T> GetAll()
        {
           return _dataAccessLayer.GetAll();
        }
    }
}
