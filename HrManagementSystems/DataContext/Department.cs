using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrManagementSystems.DataContext
{
    public class Department
    {
        public Int32 DepartmentId { set; get; }  
        public String DepartmentName { set; get; }
        public Int32 ManagerId { set; get; }
    }
}
