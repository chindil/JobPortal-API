using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stx.Shared;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.Interfaces.HRM
{
    public interface IEmployeeRepository
    {
        IEnumerable<HrEmployee> GetAllEmployees();
        HrEmployee GetEmployeeById(int employeeId);
        HrEmployee AddEmployee(HrEmployee employee);
        HrEmployee UpdateEmployee(HrEmployee employee);
        void DeleteEmployee(int employeeId);
    }
}
