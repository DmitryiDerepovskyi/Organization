using System.Text.RegularExpressions;
using Organization.Contract.BusinessLogic;
using System;
using Organization.Contract.DAL;
using Organization.Core;

namespace Organization.BusinessLogic.Validators
{
    public class CustomerValidator : IValidator<Customer>
    {
        private readonly IDataAccessLayer<Customer> _customerDal;

        public CustomerValidator(IDataAccessLayer<Customer> customerDal)
        {
            _customerDal = customerDal;
        }

        public bool IsValid(Customer entity)
        {
            if(entity == null) throw new ArgumentNullException();

            var regexName = new Regex(PatternsRegex.Name);
            var regexPhone = new Regex(PatternsRegex.Phone);
            return regexName.IsMatch(entity.ContactName) &&
                   regexPhone.IsMatch(entity.Phone);
        }

        public bool IsExists(params object[] key)
        {
             if (key == null) throw new ArgumentNullException();
            if (key.Length != 1) throw new ArgumentException("Key is wrong!");
            if (!(key[0] is int)) throw new ArgumentException("Key is not a number!"); 
            return _customerDal.GetByPrimaryKey(key) != null;
        }
    }
}
