using System;
using Organization.Contract.BusinessLogic;
using Organization.Contract.DAL;
using Organization.Core;

namespace Organization.BusinessLogic.Validators
{
    public class EquipmentContractValidator : IValidator<EquipmentContract>
    {
        private readonly IDataAccessLayer<EquipmentContract> _dal; 
        private readonly IValidator<Equipment> _equipmentValidator; 
        private readonly IValidator<Core.Contract> _contractValidator; 
        public EquipmentContractValidator(IDataAccessLayer<EquipmentContract> dal,
            IValidator<Equipment> equipmentValidator,
            IValidator<Core.Contract> contractValidator)
        {
            _dal = dal;
            _equipmentValidator = equipmentValidator;
            _contractValidator = contractValidator;
        }

        public bool IsValid(EquipmentContract entity)
        {
            if(entity == null) throw new ArgumentNullException();

            return _equipmentValidator.IsExists(entity.EquipmentId) && 
                _contractValidator.IsExists(entity.ContractId);
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
