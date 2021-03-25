using HrManagementSystems.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrManagementSystems.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataProviderController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DataProviderController> _logger;

        String connectionString = 
            "Data Source = .\\SQLExpress; Integrated Security = SSPI; Initial Catalog=HrManagementSystem";

        [Route("ManagerList")]
        public List<Object> ManagerList()
        {

            Database db = new Database(connectionString);
            var departments = db.Departments.ToList();
            var employees = db.Employees.ToList(); 

            List<Object> output = new List<Object>(); 

            foreach (var department in departments)
            {
                var manager = employees.Where(e => e.EmployeeId == department.ManagerId).FirstOrDefault();
                var currentEmployee = new { DepartmentName = department.DepartmentName, ManagerName = manager.EmployeeName };
                output.Add(currentEmployee);
            }

            return output; 

        }

        [Route("EmployeeAgingBetween")]
        public List<Object> EmployeeAgingBetween()
        {
            Database db = new Database(connectionString);
            
                var employees = db.Employees.Where(
                a => (DateTime.Now.Year - a.EmployeeDOB.Year) >= 20
                && (DateTime.Now.Year - a.EmployeeDOB.Year) <= 40
                && a.EmployeeSalary >= 2000);
                

            List<Object> output = new List<Object>();

            foreach (var employee in employees)
            {
                output.Add
                    (new { EmployeeName = employee.EmployeeName , 
                        EmployeeDOB = String.Format("{0:yyyy/MM/dd}", employee.EmployeeDOB) , 
                        EmployeeSalary = String.Format("{0:c}" , employee.EmployeeSalary)
                    });
            }

            return output;
        }

        public DataProviderController(ILogger<DataProviderController> logger)
        {
            

        
        }

        [Route("HighestPaidEmployeeList")]
        public List<Object> HighestPaidEmployeeList()
        {

            Database db = new Database(connectionString);
            var departments = db.Departments.ToList();
            var employees = db.Employees.ToList();

            List<Object> output = new List<Object>();
          
            

            foreach (var department in departments)
            {

                Employee maxEmployee = null;
               

                var departmentEmployee = employees.Where(p => p.DepartmentId == department.DepartmentId).ToList();

                foreach (var employee in departmentEmployee)
                {
                    if (maxEmployee == null || maxEmployee.EmployeeSalary < employee.EmployeeSalary)
                        maxEmployee = employee;                        
                }

                if (maxEmployee != null)
                    output.Add(
                            new
                            {
                                DepartmentName = department.DepartmentName ,
                                EmployeeName = maxEmployee.EmployeeName,
                                Salary = maxEmployee.EmployeeSalary
                            }
                        );
                     
            }

            return output;

        }
                

        [Route("YoungestEmployeeList")]
        public List<Object> YoungestEmployeeList()
        {

            Database db = new Database(connectionString);
            var departments = db.Departments.ToList();
            var employees = db.Employees.ToList();

            List<Object> output = new List<Object>();

            foreach (var department in departments)
            {

                Employee minAgeEmployee = null;


                var departmentEmployee = employees.Where(p => p.DepartmentId == department.DepartmentId).ToList();

                foreach (var employee in departmentEmployee)
                {
                    if (minAgeEmployee == null || minAgeEmployee.EmployeeDOB > employee.EmployeeDOB)
                        minAgeEmployee = employee;
                }

                if (minAgeEmployee != null)
                    
                    output.Add(
                            new
                            {
                                DepartmentName = department.DepartmentName,
                                EmployeeName = minAgeEmployee.EmployeeName,
                                DateOfBirth = String.Format("{0:yyyy/MM/dd}", minAgeEmployee.EmployeeDOB)
                            }
                        );

            }

            return output;

        }



    }
}
