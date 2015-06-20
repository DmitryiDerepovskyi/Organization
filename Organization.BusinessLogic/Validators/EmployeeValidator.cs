using System;
using System.Linq;
using Organization.Contract.BusinessLogic;
using Organization.Contract.DAL;
using Organization.Core;
using System.Text.RegularExpressions;
namespace Organization.BusinessLogic.Validators
{
    public class EmployeeValidator : IValidator<Employee>
    {
        private readonly IDataAccessLayer<Employee> _dal;
        private readonly IValidator<Department> _departmentValidator;

        public EmployeeValidator(IDataAccessLayer<Employee> dal, 
            IValidator<Department> departmentValidator)
        {
            _dal = dal;
            _departmentValidator = departmentValidator;
        }

        public bool IsValid(Employee entity)
        {
            if(entity == null) throw new ArgumentNullException();

            var arrayGender = new []{'g', 'm'};
            var regexName = new Regex(PatternsRegex.Name);
            var regexPhone = new Regex(PatternsRegex.Phone);
            return  regexName.IsMatch(entity.FirstName) && regexName.IsMatch(entity.LastName) &&
                  arrayGender.Contains(Char.ToLower(entity.Gender)) && regexPhone.IsMatch(entity.Phone) &&
                  entity.Salary > 0 && _departmentValidator.IsExists(entity.DepartmentId);
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
