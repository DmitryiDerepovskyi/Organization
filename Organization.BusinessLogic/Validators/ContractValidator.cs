using System;
using Organization.Contract.BusinessLogic;
using Organization.Contract.DAL;
using Organization.Core;

namespace Organization.BusinessLogic.Validators
{
    public class ContractValidator : IValidator<Core.Contract>
    {
        private readonly IDataAccessLayer<Core.Contract> _dal;
        private readonly IValidator<Customer> _customerValidator;
        private readonly IValidator<Department> _departmentValidator;

        public ContractValidator(IValidator<Customer> customerValidator, 
            IValidator<Department> departmentValidator,
            IDataAccessLayer<Core.Contract> dal)
        {
            _customerValidator = customerValidator;
            _departmentValidator = departmentValidator;
            _dal = dal;
        }

        public bool IsValid(Core.Contract entity)
        {
            if(entity == null) throw new ArgumentNullException();

            return entity.Price > 0 && _customerValidator.IsExists(entity.CustomerId) &&
                   _departmentValidator.IsExists(entity.DepartmentId);
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
