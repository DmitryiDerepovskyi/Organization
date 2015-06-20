using System;
using Organization.Contract.BusinessLogic;
using Organization.Contract.DAL;
using Organization.Core;
using System.Text.RegularExpressions;
namespace Organization.BusinessLogic.Validators
{
    public class DepartmentValidator : IValidator<Department>
    {
        private readonly IDataAccessLayer<Department> _dal;

        public DepartmentValidator(IDataAccessLayer<Department> dal)
        {
            _dal = dal;
        }
        public bool IsValid(Department entity)
        {
            if(entity == null) throw new ArgumentNullException();
            var regex = new Regex(PatternsRegex.DepartmentName);
            return regex.IsMatch(entity.Name);
        }

        public bool IsExists(params object[] key)
        {
             if (key == null) throw new ArgumentNullException();
            if (key.Length != 1) throw new ArgumentException("Key is wrong!");
            if (!(key[0] is int)) throw new ArgumentException("Key is not a number!"); 
            return _dal.GetByPrimaryKey(key) != null;
        }
    }
}
