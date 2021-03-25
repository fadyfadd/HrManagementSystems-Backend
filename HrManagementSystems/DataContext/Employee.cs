using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrManagementSystems.DataContext
{
    public class Employee
    {
        public Int32 EmployeeId { set; get; }
        public Int32 DepartmentId { set; get; }
        public String EmployeeName { set; get; }
        public decimal EmployeeSalary { set; get; }
        public DateTime EmployeeDOB { set; get; }
       
        
    }
}
