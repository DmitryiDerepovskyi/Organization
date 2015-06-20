using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organization.Contract.BusinessLogic;
using Organization.Core;

namespace Organization.BusinessLogic
{
    public class Logic : ILogic
    {
        protected virtual IEnumerable<Employee> Employees { get; set; }
        protected virtual IEnumerable<Core.Contract> Contracts { get; set; }

        public Logic(IManager<Employee> managerEmployee, IManager<Core.Contract> managerContract)
        {
            Employees = managerEmployee.GetAll();
            Contracts = managerContract.GetAll();
        }
        public decimal AverageSalary()
        {
            var enumerable = Employees as IList<Employee> ?? Employees.ToList();
            return enumerable.Average(employee => employee.Salary);
        }
        public decimal TotalPriceContract()
        {
            var enumerable = Contracts as IList<Core.Contract> ?? Contracts.ToList();
            return enumerable.Sum(contract => contract.Price);
        }
    }
}
