using System.Collections.Generic;
using System.Linq;
using Stx.Api.Hrm.Interfaces.HRM;
using Stx.Shared;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.Repos.HRM
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StxDbContext _appDbContext;

        public EmployeeRepository(StxDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<HrEmployee> GetAllEmployees()
        {
            //return _appDbContext.Employees;

            return null;

        }

        public HrEmployee GetEmployeeById(int employeeId)
        {
            //return _appDbContext.Employees.FirstOrDefault(c => c.EmployeeID == employeeId);

            return null;

        }

        public HrEmployee AddEmployee(HrEmployee employee)
        {
            //var addedEntity = _appDbContext.Employees.Add(employee);
            //_appDbContext.SaveChanges();
            //return addedEntity.Entity;

            return null;

        }

        public HrEmployee UpdateEmployee(HrEmployee employee)
        {
            //var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);

            //if (foundEmployee != null)
            //{
            //    foundEmployee.CountryID = employee.CountryID;
            //    foundEmployee.MaritalStatus = employee.MaritalStatus;
            //    foundEmployee.BirthDate = employee.BirthDate;
            //    foundEmployee.City = employee.City;
            //    foundEmployee.Email = employee.Email;
            //    foundEmployee.FirstName = employee.FirstName;
            //    foundEmployee.LastName = employee.LastName;
            //    foundEmployee.Gender = employee.Gender;
            //    foundEmployee.PhoneNumber = employee.PhoneNumber;
            //    foundEmployee.Smoker = employee.Smoker;
            //    foundEmployee.Street = employee.Street;
            //    foundEmployee.Zip = employee.Zip;
            //    foundEmployee.JobCategoryID = employee.JobCategoryID;
            //    foundEmployee.Comment = employee.Comment;
            //    foundEmployee.ExitDate = employee.ExitDate;
            //    foundEmployee.JoinedDate = employee.JoinedDate;

            //    _appDbContext.SaveChanges();

            //    return foundEmployee;
            //}

            return null;
        }

        public void DeleteEmployee(int employeeId)
        {
            //var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            //if (foundEmployee == null) return;

            //_appDbContext.Employees.Remove(foundEmployee);
            //_appDbContext.SaveChanges();


            return;

        }
    }
}
