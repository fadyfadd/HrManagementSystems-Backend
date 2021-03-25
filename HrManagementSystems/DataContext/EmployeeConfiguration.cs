using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrManagementSystems.DataContext
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees", "dbo");
            builder.HasKey(a => a.EmployeeId);
            builder.Property(a => a.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(a => a.EmployeeName).HasColumnName("EmployeeName");
            builder.Property(a => a.EmployeeSalary).HasColumnName("EmployeeSalary");
            builder.Property(a => a.DepartmentId).HasColumnName("DepartmentId");
            builder.Property(a => a.EmployeeDOB).HasColumnName("EmployeeDOB");


        }
    }
}
