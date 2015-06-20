using System;
using Organization.Contract.BusinessLogic;
using Organization.Contract.DAL;
using Organization.Core;

namespace Organization.BusinessLogic.Validators
{
    public class EquipmentValidator : IValidator<Equipment>
    {
        private readonly IDataAccessLayer<Equipment> _dal;
        private readonly IValidator<Department> _departmentValidator;

        public EquipmentValidator(IValidator<Department> departmentValidator,
            IDataAccessLayer<Equipment> dal)
        {
            _dal = dal;
            _departmentValidator = departmentValidator;
        }

        public bool IsValid(Equipment entity)
        {
            if(entity == null) throw new ArgumentNullException("entity");

            return !String.IsNullOrWhiteSpace(entity.Name) && 
                (entity.DepartmentId == null) || _departmentValidator.IsExists(entity.DepartmentId);

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
