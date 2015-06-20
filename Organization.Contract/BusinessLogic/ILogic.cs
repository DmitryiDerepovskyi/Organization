using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organization.Contract.Core;

namespace Organization.Contract.BusinessLogic
{
    public interface ILogic
    {
         decimal AverageSalary();
         decimal TotalPriceContract();
    }
}
